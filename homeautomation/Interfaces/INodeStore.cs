using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using homeautomation.DataModel;
//using Xamarin.Forms.Pages;

namespace homeautomation.Interfaces
{
    public interface INodeStore
    {
        ObservableCollection<INode> Nodes { get; set; }
        //IDataSource NodesDataSource { get; }

        event NodeChangeDelegate NodeChanged;

        Task StartNodeBinding(IApiHandler apiHandler, IWebSocketHandler socket);
    }
}
