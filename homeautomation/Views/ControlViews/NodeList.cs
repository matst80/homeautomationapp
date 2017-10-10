using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using homeautomation.Interfaces;
using Xamarin.Forms;

namespace homeautomation.Views
{
    public class NodeList : StackLayout
    {
      

        void Nodes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action== System.Collections.Specialized.NotifyCollectionChangedAction.Add) {
                foreach (var n in e.NewItems.OfType<INode>())
				{
					this.Children.Add(CreateDefault(n));
				} 
            }
        }

        public NodeList() : base() {
            
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


                foreach (var n in Nodes)
                {
                    this.Children.Add(CreateDefault(n));
                }
				Nodes.CollectionChanged += Nodes_CollectionChanged;

			
        }

        protected NodeSelectorView CreateDefault(INode item)
        {
            var ret = new NodeSelectorView();
            ret.BindingContext = item;
            return ret;
        }
    }
}

