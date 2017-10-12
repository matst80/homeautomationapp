using System;
using System.Windows.Input;
using homeautomation.Views.NodeViews;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace homeautomation.DataModel
{
    public class SetState
    {

        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("brightness")]
        public int Brightness { get; set; }
    }

    [Helpers.NodeFeature("brightness")]
    public class BrightnessNode : OnOffNode
    {
        public BrightnessNode()
        {

        }

        public int Brightness { get; set; }

        public ICommand SetBrightness => new Command((obj) =>
        {
            if (obj is int)
            {
                var d = obj as int?;
                obj = new SetState()
                {
                    State = d > 0 ? 1 : 0,
                    Brightness = (int)d
                };
            }
            base.SendState.Execute(obj);
        });

        private Type viewType = typeof(BrightnessNodeView);

        public override Type GetViewType()
        {
            return viewType;
        }

        public override Color BackgroundColor
        {
            get
            {
                return Color.FromHex("#f1c40f");
            }
            set
            {
                base.BackgroundColor = value;
            }
        }

        public override void Parse(DataNode node)
        {
            base.Parse(node);
            var newBrightness = 0;
            if (node.State is JObject)
            {
                var o = node.State as JObject;


                IsPowerdOn = o.GetValue("state")?.Value<int>() > 0;
                if (IsPowerdOn)
                    Brightness = o.GetValue("brightness")?.Value<int>() ?? 0;
                else
                    Brightness = 0;
            }
            else
            {
                if (int.TryParse(node.State.ToString(), out newBrightness))
                {
                    Brightness = newBrightness;
                    IsPowerdOn = Brightness > 0;
                }
                else
                {
                    //IsPowerdOn = node.State.ToString() == "on";
                    Brightness = IsPowerdOn ? 100 : 0;
                }
            }
        }
    }
}
