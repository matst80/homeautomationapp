using System;
using homeautomation.Interfaces;
using Newtonsoft.Json.Linq;

namespace homeautomation.DataModel
{
    [Helpers.NodeFeature("temp")]
    public class TemperatureAndHumidityNode : BaseNode
    {
        public TemperatureAndHumidityNode()
        {
        }

        public float Temperature
        {
            get;
            set;
        }

        public float Humidity
        {
            get;
            set;
        }

        public override void Parse(IDataNode node)
        {
            base.Parse(node);
            var temphum = node.State as JContainer;
            Humidity = temphum["hum"].Value<float>();
            Temperature = temphum["temp"].Value<float>();
            StringRepresentation = Temperature + "°, " + Humidity + "%";
            // TODO Parse temp and humidity to properties
            //StringRepresentation = "22";
        }

    }
}
