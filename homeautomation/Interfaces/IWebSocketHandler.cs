using System.Threading.Tasks;
using Newtonsoft.Json;

namespace homeautomation.Interfaces
{
    public class JsonMessage
    {

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("data")]
        public object Data
        {
            get;
            set;
        }
    }

    public delegate void WebSocketMessageEventArgs(JsonMessage message);

    public interface IWebSocketHandler
    {
        Task StartListening();
        void Subscribe(string topic, WebSocketMessageEventArgs onmessage);
    }
}