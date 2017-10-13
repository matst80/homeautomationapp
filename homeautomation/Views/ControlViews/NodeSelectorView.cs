using System;
using System.Windows.Input;
using homeautomation.Interfaces;
using Xamarin.Forms;

namespace homeautomation.Views
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class NodeSelectorView : Layout<View>
    {
        
		public INode Node
		{
			get; set;
		}

        private BaseNodeContentView currentView = new BaseNodeContentView();
        private Label settingsLabel;
        private Button settingsButton;
       

        public NodeSelectorView()
        {
            var iconColor = Color.FromHex("#bdc3c7");
            //BackgroundColor = Color.White;
            //HasShadow = false;
            //CornerRadius = 0;
            //OutlineColor = iconColor;
            Padding = new Thickness(8);
            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Fill;
            //Margin = new Thickness(5, 10);
            /*var baseView = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };*/
            currentView = new BaseNodeContentView();

            //baseView.BackgroundColor = Color.Transparent;
            //Content = baseView;
            settingsButton = new Button()
            {
                Text = "\uf013",
                TextColor = iconColor,
                FontSize = 20,
                FontFamily = "FontAwesome"
            };
            settingsLabel = new Label()
            {
                TextColor = iconColor,
                HorizontalTextAlignment = TextAlignment.End,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 14,
                Text = "Settings"
            };
            settingsButton.Command = new Command(() =>
            {
                //(App.Current.MainPage as MasterDetailPage).Navigation.PushModalAsync(new NodeItemView(Node));
                App.Current.MainPage.Navigation.PushAsync(new NodeItemView(Node));
            });
            Children.Add(currentView);
            Children.Add(settingsLabel);
            Children.Add(settingsButton);
            //baseView.Children.Add(currentView);
            //Children.Add(Stack);
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
                   
                    Children.Remove(currentView);
                    currentView = Activator.CreateInstance(newViewType) as BaseNodeContentView;
                    //currentView.BackgroundColor = Color.Transparent;
                    Children.Add(currentView);

                }
            }
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            var r = x + width;
            var b = y + height;
            currentView.Layout(new Rectangle(x + 10, y + 10, width - 20, height - 25));
            settingsButton.Layout(new Rectangle(r - 30, b - 30, 30, 30));
            settingsLabel.Layout(new Rectangle(x, b - 30, width - 30, 30));
        }

    }
}

