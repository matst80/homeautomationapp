using System;
using homeautomation.Interfaces;
using Xamarin.Forms;

namespace homeautomation.Views
{

    public class BaseNodeContentView : ContentView
    {
        /*public static readonly BindableProperty NodeProperty = BindableProperty.Create("Node", typeof(INode), typeof(BaseNodeContentView), null, BindingMode.TwoWay);

		public INode Node
		{
			get { return (INode)GetValue(NodeProperty); }
			set { SetValue(NodeProperty, value); }
		}*/

        public INode Node
        {
            get
            {
                return BindingContext as INode;
            }
        }
    }
}

