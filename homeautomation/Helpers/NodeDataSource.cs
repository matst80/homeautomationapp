using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using homeautomation.Interfaces;
//using Xamarin.Forms.Pages;

namespace homeautomation.BL
{
    /*
    public class NodeDataSource : Xamarin.Forms.Pages.IDataSource
    {
        void Nodes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems.OfType<INode>())
                {
                    nodeDataItems.Add(item.Topic, item);
                }
            }
        }

        public NodeDataSource(ObservableCollection<INode> nodes)
        {
            nodeDataItems = new Dictionary<string, IDataItem>();
            nodes.CollectionChanged += Nodes_CollectionChanged;
            foreach (var n in nodes)
            {
                nodeDataItems.Add(n.Topic, n);
            }
        }
        private Dictionary<string, IDataItem> nodeDataItems;

        public object this[string key]
        {
            get
            {
                return nodeDataItems[key];
            }
            set
            {
                nodeDataItems[key].Value = value;
            }
        }

        public IReadOnlyList<IDataItem> Data
        {
            get
            {
                return nodeDataItems.Values.ToList();
            }
        }

        public bool IsLoading
        {
            get
            {
                return nodeDataItems.Count() < 2;
            }
        }

        private List<string> maskedKeys = new List<string>();

        public IEnumerable<string> MaskedKeys
        {
            get
            {
                return maskedKeys;
            }
        }

        public void MaskKey(string key)
        {
            maskedKeys.Add(key);
        }

        public void UnmaskKey(string key)
        {
            maskedKeys.Remove(key);
        }
    }
    */
}