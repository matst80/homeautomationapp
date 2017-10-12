using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using homeautomation.DataModel;
using homeautomation.Interfaces;
using Xamarin.Forms;

namespace homeautomation.Helpers
{
    public class StateHelper
    {
        public StateHelper()
        {
            Settings = new BL.DummySettings();
			ApiHandler = new BL.ApiHandler(Settings);
            NodeStore = new BL.NodeStore();
            WebSocketHandler = new BL.WebSocketHelper(Settings.WebSocketUri);

			var nodeType = typeof(INode);
			var types = this.GetType().Assembly.GetExportedTypes();
			foreach (var t in types)
			{
				if (nodeType.IsAssignableFrom(t))
				{
					var attr = t.GetCustomAttributes(typeof(NodeFeatureAttribute), true).OfType<NodeFeatureAttribute>().FirstOrDefault();
					if (attr != null)
					{
						NodeTypes.Add(attr.Features, t);
					}
				}
				if (nodeType.IsAssignableFrom(t))
				{
					var attr = t.GetCustomAttributes(typeof(NodeViewAttribute), true).OfType<NodeViewAttribute>().FirstOrDefault();
					if (attr != null)
					{
						NodeViews.Add(attr.NodeType, t);
					}
				}
			}
        }

        public INode CreateNodeFromData(DataNode node)
        {
            return Activator.CreateInstance(GetNodeType(node.Features[0])) as INode;
        }

        public Type GetNodeType(string feature) {
            var kv = NodeTypes.FirstOrDefault(d => feature.Equals(d.Key));
            return kv.Value ?? typeof(BaseNode);
        }

        public Type GetViewType(INode node)
        {
            var kv = NodeViews.FirstOrDefault(d => node.Features[0].Equals(d.Key));
            return kv.Value ?? typeof(Views.NodeViews.BasicNodeView);
        }

        public Dictionary<string, Type> NodeTypes = new Dictionary<string, Type>();

        public Dictionary<string, Type> NodeViews = new Dictionary<string, Type>();


		public bool IsConnected { get; internal set; }

        public async System.Threading.Tasks.Task ConnectAsync()
        {
            if (!IsConnected)
            {
                IsConnected = true;
                await NodeStore.StartNodeBinding(ApiHandler,WebSocketHandler);
            }
        }



        public Interfaces.ISettings Settings { get; private set; }
        public Interfaces.INodeStore NodeStore { get; private set; }
        public Interfaces.IApiHandler ApiHandler { get; private set; }
        public Interfaces.IWebSocketHandler WebSocketHandler { get; private set; }

        private static StateHelper _instance;
        public static StateHelper Instance {
            get
            {
                return _instance ?? (_instance = new StateHelper());
            }
        }
    }
}
