using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace homeautomation.DataModel
{
    [Helpers.NodeFeature("brightness")]
    public class BrightnessNode : OnOffNode
    {
        public BrightnessNode()
        {
        }

        public int Brightness { get; set; }

		public ICommand SetBrightness => new Command((obj) =>
		{
			base.SendState.Execute(obj);
		});

        public override void Parse(Interfaces.IDataNode node)
        {
            base.Parse(node);
            var newBrightness = 0;
            if (int.TryParse(node.State.ToString(),out newBrightness)) {
                Brightness = newBrightness;
                IsPowerdOn = Brightness > 0;
            }
            else {
                //IsPowerdOn = node.State.ToString() == "on";
                Brightness = IsPowerdOn ? 100 : 0;
            }

        }
    }
}
