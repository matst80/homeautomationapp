using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using homeautomation.DataModel;
using homeautomation.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
//using Xamarin.Forms.Pages;

namespace homeautomation.BL
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class NodeStore : INodeStore
    {

        public event NodeChangeDelegate NodeChanged;

		internal INode GetNodeInstance(IDataNode node)
		{
			var ret = Nodes.FirstOrDefault(d => d.Topic == node.Topic);
			var isNew = false;
			if (ret == null)
			{
                ret = Helpers.StateHelper.Instance.CreateNodeFromData(node);
                /*var kv = Helpers.StateHelper.Instance.NodeTypes.FirstOrDefault(d => node.Features[0].Equals(d.Key));

				if (kv.Value != null)
				{
					ret = Activator.CreateInstance(kv.Value) as INode;
				}
				else
					ret = new DataModel.BaseNode();*/
				isNew = true;

			}


            ret.Parse(node);
			if (isNew)
                Nodes.Add(ret);
            //});
			
            NodeChanged?.Invoke(ret);
                
			
			return ret;
		}

        void HandleNodeChange(Interfaces.IDataNode node)
        {
            
                var realNode = GetNodeInstance(node);

            //HandleNode(realNode);
        }

        public NodeStore() {
            Nodes = new ObservableCollection<INode>();
            //NodesDataSource = new NodeDataSource(Nodes);
        }

        public ObservableCollection<INode> Nodes { get; set; }

        /*
        public IDataSource NodesDataSource {
            get;
            private set;
        }
        */
      

        public async Task StartNodeBinding(IApiHandler apiHandler, IWebSocketHandler socket)
        {
            //apiHandler.DataNodeChanged += HandleNodeChange;
			var nodes = await apiHandler.GetNodes();
            //nodes.Select(GetNodeInstance);
			foreach (var node in nodes)
			{
                GetNodeInstance(node);
                //Nodes.Add(realNode);
			}

            socket.Subscribe("homeninja/nodechange", (JsonMessage message) => {
                var node = message.Data as JContainer;
                if (node != null)
                {
                    var dataNodes = node.ToObject<IEnumerable<DataNode>>();
                    foreach (var n in dataNodes.OfType<IDataNode>()) {
                        GetNodeInstance(n);
                    }

                }
            });
            await socket.StartListening();
        }
    }
}