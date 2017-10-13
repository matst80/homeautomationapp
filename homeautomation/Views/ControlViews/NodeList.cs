using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using homeautomation.Interfaces;
using Xamarin.Forms;

namespace homeautomation.Views
{
    public class NodeList : Layout<View>
    {


        void Nodes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var n in e.NewItems.OfType<INode>())
                {
                    this.Children.Add(CreateDefault(n));
                }
            }
        }

        public NodeList() : base()
        {

        }

        public static readonly BindableProperty NodesProperty = BindableProperty.Create("Nodes", typeof(ObservableCollection<INode>), typeof(NodeList), null, BindingMode.TwoWay);

        public ObservableCollection<INode> Nodes
        {
            get { return (ObservableCollection<INode>)GetValue(NodesProperty); }
            set { SetValue(NodesProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (Nodes != null)
            {
                foreach (var n in Nodes)
                {
                    this.Children.Add(CreateDefault(n));
                }
                Nodes.CollectionChanged += Nodes_CollectionChanged;
            }

        }

        private Random rnd = new Random();


        private Color[] Colors = new[] { Color.FromHex("#2ecc71"), Color.FromHex("#3498db"), Color.FromHex("#9b59b6"), Color.FromHex("#1abc9c") };

        protected View CreateDefault(INode item)
        {
            var ret = new NodeSelectorView();

            ret.BindingContext = item;
            ret.BackgroundColor = Colors[rnd.Next(0, 2)];
            //ret.Opacity = 0;
            //ret.FadeTo(1,500,Easing.SinIn);
            return ret;
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            var row = 0;
            var i = 0;
            var cols = Math.Floor(width / 150);

            var offset = 7;
            var iw = (width / cols) - (offset);
            var ih = iw * 0.8;


            foreach(var view in Children) {
                view.Layout(new Rectangle((i * iw) + offset, (row * ih) + offset, (iw - offset), (ih - offset)));
                if (++i >= cols)
                {
                    row++;
                    i = 0;
                }

                view.WidthRequest = iw;
                view.HeightRequest = ih;
            }
            HeightRequest = ih * (row + 1);
        }
    }
}

