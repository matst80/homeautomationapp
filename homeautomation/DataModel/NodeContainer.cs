using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using homeautomation.Interfaces;

namespace homeautomation.DataModel
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class NodeContainer : INodeContainer
    {
        public NodeContainer() {
            Nodes = new ObservableCollection<INode>();
        }
        public string Title { get; set; }
        public string Id { get; set; }
        public ObservableCollection<INode> Nodes { get; internal set; }

        private List<string> missingNodes = new List<string>();

        public void Parse(DataNodeContainer data)
        {
            var ns = Helpers.StateHelper.Instance.NodeStore;
            Title = data.Title;
            Id = data.Id;
            foreach(var item in data.Items) {
                var node = ns.Nodes.FirstOrDefault(d => d.Topic == item);
                if (node != null)
                {
                    Nodes.Add(node);
                    if (missingNodes.Contains(item))
                        missingNodes.Remove(item);
                }
                else
                {
                    missingNodes.Add(item);
                }
            }
            if (missingNodes.Any()) {
                ns.NodeChanged += (node) => {
                    if (missingNodes.Contains(node.Topic))
                    {
                        Nodes.Add(node);
                        missingNodes.Remove(node.Topic);
                    }
                };
            }
        }

       
    }
}
