using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace homeautomation.DataModel
{
    public class DataNode 
    {

        [JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "topic")]
		public string Topic { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "state")]
		public object State { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "lastSeen")]
        public string LastSeen { get; set; }

		//public object RawData { get; set; }

		[JsonProperty(PropertyName = "features")]
		public string[] Features { get; set; }
	}

}
