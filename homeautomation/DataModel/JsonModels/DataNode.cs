using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace homeautomation.DataModel
{
    public class DataNode : Interfaces.IDataNode
    {

        [JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "topic")]
		public string Topic { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "state")]
		public object State { get; set; }

		//public object RawData { get; set; }

		[JsonProperty(PropertyName = "features")]
		public string[] Features { get; set; }
	}

}
