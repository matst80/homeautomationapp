using System;
using System.Windows.Input;
using homeautomation.Interfaces;
using Xamarin.Forms;

namespace homeautomation.Views
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class NodeSelectorView : Frame
    {
        private BaseNodeContentView currentView = new BaseNodeContentView();

		public INode Node
		{
			get; set;
		}

       

        public NodeSelectorView()
        {
            BackgroundColor = Color.Transparent;
            var baseView = new StackLayout();
            baseView.BackgroundColor = Color.Transparent;
            Content = baseView;
            var openButton = new Button()
            {
                Text = "Settings",
                VerticalOptions = LayoutOptions.End
            };
            openButton.Command = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushAsync(new NodeItemView(Node));
            });
            //baseView.Children.Add(currentView);
            baseView.Children.Add(openButton);
        }

        //public static readonly BindableProperty NodeProperty = BindableProperty.Create("Node", typeof(INode), typeof(NodeSelectorView), null, BindingMode.TwoWay, propertyChanged: NodeChanges);

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            Node = BindingContext as INode;
            if (Node != null)
            {
                //var currentView = Content;
                var newViewType = Node.GetViewType();
                if (currentView.GetType() != newViewType)
                {
                    

                    var sl = Content as StackLayout;
                    sl.Children.Remove(currentView);
                    currentView = Activator.CreateInstance(newViewType) as BaseNodeContentView;
                    sl.Children.Add(currentView);
                    //Content = currentView;
                }
            }
        }
        /*private static void NodeChanges(BindableObject bindable, object oldValue, object newValue)
        {
            
            //o.Content = currentView;
        }*/



	}
}

