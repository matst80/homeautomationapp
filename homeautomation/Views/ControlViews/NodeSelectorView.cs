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
            var iconColor = Color.FromHex("#bdc3c7");
            //BackgroundColor = Color.White;
            //HasShadow = false;
            CornerRadius = 0;
            OutlineColor = iconColor;
            Padding = new Thickness(8);
            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Fill;
            //Margin = new Thickness(5, 10);
            var baseView = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            //baseView.BackgroundColor = Color.Transparent;
            Content = baseView;
            var openButton = new Button()
            {
                Text = "\uf013",
                TextColor = iconColor,
                FontSize = 20,
                FontFamily = "FontAwesome",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };
            openButton.Command = new Command(() =>
            {
                //(App.Current.MainPage as MasterDetailPage).Navigation.PushModalAsync(new NodeItemView(Node));
                App.Current.MainPage.Navigation.PushAsync(new NodeItemView(Node));
            });
            var Stack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                //BackgroundColor = Color.FromHex("#ecf0f1"),
                VerticalOptions = LayoutOptions.End
            };
            Stack.Children.Add(new Label()
            {
                TextColor = iconColor,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 14,
                Text = "Settings"
            });
            Stack.Children.Add(openButton);
            //baseView.Children.Add(currentView);
            baseView.Children.Add(Stack);
        }

        //public static readonly BindableProperty NodeProperty = BindableProperty.Create("Node", typeof(INode), typeof(NodeSelectorView), null, BindingMode.TwoWay, propertyChanged: NodeChanges);

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            Node = BindingContext as INode;
            if (Node != null)
            {
                //BackgroundColor = Node.BackgroundColor;
                //var currentView = Content;
                var newViewType = Node.GetViewType();
                if (currentView.GetType() != newViewType)
                {
                    

                    var sl = Content as StackLayout;
                    sl.Children.Remove(currentView);
                    currentView = Activator.CreateInstance(newViewType) as BaseNodeContentView;
                    currentView.HorizontalOptions = LayoutOptions.StartAndExpand;
                    sl.Children.Insert(0,currentView);
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

