using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
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

		internal INode GetNodeInstance(DataNode node)
		{
			var ret = Nodes.FirstOrDefault(d => d.Topic == node.Topic);
			var isNew = false;
			if (ret == null)
			{
                ret = Helpers.StateHelper.Instance.CreateNodeFromData(node);

				isNew = true;

			}


            ret.Parse(node);
            if (isNew)
            {
                Nodes.Add(ret);
                AllNodesContainer.Nodes.Add(ret);
            }
			
            NodeChanged?.Invoke(ret);
                
			
			return ret;
		}

        internal INodeContainer GetNodeContainerInstance(DataNodeContainer ncnt)
        {
            var ret = Containers.FirstOrDefault(d => d.Id == ncnt.Id);
            var isNew = false;
            if (ret == null)
            {
                ret = new NodeContainer();
                isNew = true;

            }
            ret.Parse(ncnt);
            if (isNew)
                Containers.Add(ret);
          
            return ret;
        }

        void HandleNodeChange(DataNode node)
        {
            
                var realNode = GetNodeInstance(node);

            //HandleNode(realNode);
        }

        public NodeStore() {
            Nodes = new ObservableCollection<INode>();
            Containers = new ObservableCollection<INodeContainer>();
            Containers.Add(AllNodesContainer);
            //NodesDataSource = new NodeDataSource(Nodes);
        }

        public INodeContainer AllNodesContainer = new NodeContainer()
        {
            Id = "all",
            Title = "All nodes",
            Nodes = new ObservableCollection<INode>()
        };

        public ObservableCollection<INode> Nodes { get; set; }

        public ObservableCollection<INodeContainer> Containers { get; internal set; }

        /*
        public IDataSource NodesDataSource {
            get;
            private set;
        }
        */

        private IApiHandler apiHandler;
        private IWebSocketHandler socketHandler;

        public async Task StartNodeBinding(IApiHandler api, IWebSocketHandler socket)
        {
            apiHandler = api;
            socketHandler = socket;
            //apiHandler.DataNodeChanged += HandleNodeChange;
            try
            {
                var nodes = await apiHandler.GetNodes();
                //nodes.Select(GetNodeInstance);
                foreach (var node in nodes.OrderBy(d=>d.Name))
                {
                    GetNodeInstance(node);
                    //Nodes.Add(realNode);
                }

                var containers = await apiHandler.GetContainers();
                foreach (var cnt in containers)
                {
                    var ncnt = new NodeContainer();
                    ncnt.Parse(cnt);
                    Containers.Add(ncnt);
                }
            }
        
            catch (HttpRequestException ex)
            {
                App.ShowConnectionErrorMessage("Unable to fetch data over http", ex);
                //await App.Current.MainPage.DisplayAlert("Connection", "Unable to fetch data over http\n\r"+ex.Message, "Wait...");
                ScheduleNewDataLoad();
                return;
                //return null;
            }
            try
            {

                socket.Subscribe("homeninja/conatiners", (JsonMessage message) =>
                {
                    var node = message.Data as JContainer;
                    if (node != null)
                    {
                        var dataCnt = node.ToObject<IEnumerable<DataNodeContainer>>();
                        foreach (var n in dataCnt)
                        {
                            GetNodeContainerInstance(n);
                        }

                    }
                });

                socket.Subscribe("homeninja/nodechange", (JsonMessage message) =>
                {
                    var node = message.Data as JContainer;
                    if (node != null)
                    {
                        var dataNodes = node.ToObject<IEnumerable<DataNode>>();
                        foreach (var n in dataNodes)
                        {
                            GetNodeInstance(n);
                        }

                    }
                });
                await socket.StartListening();
            }
            catch(WebSocketException ex) {
                App.ShowConnectionErrorMessage("Unable to fetch data over websocket", ex);
                ScheduleNewDataLoad();
            }
        }

       

        private void ScheduleNewDataLoad() => Task.Delay(TimeSpan.FromSeconds(30)).ContinueWith(async task =>
        {
            await StartNodeBinding(apiHandler,socketHandler);
        });

    }
}