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
            base.SendState.Execute(((bool)obj)?"on":"off");
        });

        private Type viewType = typeof(Views.NodeViews.OnOffNodeView);
        public override Type GetViewType()
        {
            return viewType;
        }

        public override void Parse(Interfaces.IDataNode node)
        {
            base.Parse(node);
            //Name += ".";
            IsPowerdOn = node.State.ToString() == "on";
            StringRepresentation = IsPowerdOn ? "On" : "Off";

        }
    }
}
