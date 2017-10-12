using System;
using homeautomation.Interfaces;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

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

        public override Xamarin.Forms.Color BackgroundColor
        {
            get
            {
                return Color.FromHex("#e74c3c");
            }
            set
            {
                base.BackgroundColor = value;
            }
        }

        public float Humidity
        {
            get;
            set;
        }

        public override void Parse(DataNode node)
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
