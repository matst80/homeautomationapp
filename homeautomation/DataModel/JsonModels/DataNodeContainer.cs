using System;
using Newtonsoft.Json;

namespace homeautomation.DataModel
{
    public class DataNodeContainer
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "items")]
        public string[] Items { get; set; }
    }
}
