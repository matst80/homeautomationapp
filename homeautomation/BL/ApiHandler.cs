using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using homeautomation.DataModel;
using homeautomation.Interfaces;
using Newtonsoft.Json;

namespace homeautomation.BL
{

    public class SendState
    {
        //public string Id { get; set; }
        [JsonProperty(PropertyName = "topic")]
        public string Topic { get; set; }

        [JsonProperty(PropertyName = "state")]
        public object State { get; set; }
    }

    internal class ApiHandler : IApiHandler
    {
        public ApiHandler(ISettings settings) {
            httpClient.BaseAddress = new Uri("http://"+settings.HostUrl + ":" + settings.HttpApiPort);
            applicationSettings = settings;
        }

        ISettings applicationSettings;
        HttpClient httpClient = new HttpClient();

		public async Task<bool> SendState(INode node, object state)
		{
            var ret = await Post($"/api/sendstate", new SendState() {
                Topic = node.Topic+"/set",
                State = state
            });
            return ret.IsSuccessStatusCode;
		}

        private async Task<Tret> JsonGet<Tret>(string url) {
            
            var json = await httpClient.GetStringAsync(url);
            return await Task.Run(() => JsonConvert.DeserializeObject<Tret>(json));
            
        }

        public async Task<IEnumerable<DataNode>> GetNodes()
        {
            return await JsonGet<IEnumerable<DataNode>>($"api/node");
			//var json = await httpClient.GetStringAsync($"api/node");
			//return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<DataNode>>(json));
        }

		public async Task<HttpResponseMessage> Post(string url, object item)
		{
            var serializedItem = JsonConvert.SerializeObject(item);
            return await httpClient.PostAsync(url, new StringContent(serializedItem, System.Text.Encoding.UTF8, "application/json"));
		}

        public async Task<bool> SendCustomization(CustomizationData cust) {
            var ret = await Post($"/api/customization", cust);
            return ret.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<DataNodeContainer>> GetContainers()
        {
            return await JsonGet<IEnumerable<DataNodeContainer>>($"api/container");
            //var json = await httpClient.GetStringAsync($"api/container");
            //return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<DataNodeContainer>>(json));
        }
    }
}