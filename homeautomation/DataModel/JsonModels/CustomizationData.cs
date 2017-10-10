using System;
using homeautomation.Interfaces;
using Newtonsoft.Json;

namespace homeautomation.DataModel
{

    public class Customizations {
		
        [JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
		
        [JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		
        [JsonProperty(PropertyName = "room")]
		public string Room { get; set; }
    }

    public class CustomizationData 
    {
        public CustomizationData() {
            
        }

		public CustomizationData(INode node, string name, string desc)
		{
            Topic = node.Topic;
            Customizations = new Customizations()
            {
                Name = name,
                Description = desc
            };
		}

		[JsonProperty(PropertyName = "id")]
		public string Topic { get; set; }

		[JsonProperty(PropertyName = "data")]
		public Customizations Customizations { get; set; }

		
	}

}
