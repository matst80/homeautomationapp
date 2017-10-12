using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace homeautomation.DataModel
{
    [Helpers.NodeFeature("onoff")]
    public class OnOffNode : BaseNode
    {
        public bool IsPowerdOn { get; set; }

        public OnOffNode()
        {
        }

        public Color CurrentColor {
            get{
                return IsPowerdOn ? Color.FromHex("#27ae60") : Color.FromHex("#34495e");
            }
        }

        public override Color BackgroundColor
        {
            get
            {
                return Color.FromHex("#3498db");
            }
            set
            {
                base.BackgroundColor = value;
            }
        }

		public ICommand SendOn => new Command((obj) =>
		{
            base.SendState.Execute("on");
		});

        public ICommand SendOff => new Command((obj) =>
		{
			base.SendState.Execute("off");
		});

        public ICommand SendBoolState => new Command((obj) =>
        {
            //if (IsPowerdOn != (bool)obj)
                base.SendState.Execute(((bool)obj)?"on":"off");
        });

        private Type viewType = typeof(Views.NodeViews.OnOffNodeView);
        public override Type GetViewType()
        {
            return viewType;
        }

        public override void Parse(DataNode node)
        {
            base.Parse(node);
            //Name += ".";
            var newState = node.State.ToString() == "on";
            if (IsPowerdOn != newState)
            {
                IsPowerdOn = newState;
                StringRepresentation = IsPowerdOn ? "On" : "Off";
            }
        }
    }
}
