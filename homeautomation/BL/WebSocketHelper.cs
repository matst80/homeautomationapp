using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using homeautomation.Interfaces;
using Newtonsoft.Json;

namespace homeautomation.BL
{
    public class WebSocketHelper : IWebSocketHandler
    {
        private ClientWebSocket client = new ClientWebSocket();
        private CancellationTokenSource cancelConnectSource = new CancellationTokenSource();
        private CancellationTokenSource cancelMessageSource = new CancellationTokenSource();
        private Uri serverUrl;

        private const int BUFFER_SIZE = 1024 * 32;

        public event WebSocketMessageEventArgs MessageRecieved;

        private byte[] messageBuffer = new byte[BUFFER_SIZE];

        public WebSocketHelper(Uri server) => serverUrl = server;

        public async Task StartListening() {
            // var cancelSource = new CancellationTokenSource();
            if (client.State != WebSocketState.Open)
                await client.ConnectAsync(serverUrl, cancelConnectSource.Token);
            await StartRecivingMessages();
        }

        private Dictionary<string, WebSocketMessageEventArgs> topicDelegates = new Dictionary<string, WebSocketMessageEventArgs>();

        public void Subscribe(string topic, WebSocketMessageEventArgs onmessage) {
            if (!topicDelegates.ContainsKey(topic))
                topicDelegates.Add(topic,onmessage);
        }

        private void HandleTopicSubscriptions(JsonMessage message)
        {
            WebSocketMessageEventArgs del = null;
            if (topicDelegates.TryGetValue(message.Topic, out del))
                del(message);
        }

        private JsonMessage GetMessage(string data) {
            return JsonConvert.DeserializeObject<JsonMessage>(data);
        }

       // private bool IsRecieving = false;

        private async Task StartRecivingMessages()
        {
            
            var segment = new ArraySegment<byte>(messageBuffer);

            var result = await client.ReceiveAsync(segment, cancelMessageSource.Token);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                await client.CloseAsync(WebSocketCloseStatus.InvalidMessageType, "Skit in, skit ut", CancellationToken.None);
                return;
            }

            int count = result.Count;
            while (!result.EndOfMessage)
            {
                if (count >= messageBuffer.Length)
                {
                    await client.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None);
                    return;
                }

                segment = new ArraySegment<byte>(messageBuffer, count, messageBuffer.Length - count);
                result = await client.ReceiveAsync(segment, cancelMessageSource.Token);
                count += result.Count;
            }

            var message = System.Text.Encoding.UTF8.GetString(messageBuffer, 0, count);
            var jsonMessage = GetMessage(message);
            HandleTopicSubscriptions(jsonMessage);
            MessageRecieved?.Invoke(jsonMessage);

            if (client.State != WebSocketState.Open)
                await StartRecivingMessages();
            else
                await StartListening();
        }


    }
}
