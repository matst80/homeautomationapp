using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using homeautomation.DataModel;

namespace homeautomation.Interfaces
{
    
    public delegate void NodeChangeDelegate(Interfaces.INode node);
    public delegate void DataNodeChangeDelegate(DataNode node);

    public interface IApiHandler
    {
        //Task<System.Net.Mqtt.IMqttClient> Connect();
        Task<IEnumerable<DataNode>> GetNodes();
        Task<IEnumerable<DataNodeContainer>> GetContainers();

        //event DataNodeChangeDelegate DataNodeChanged;

        Task<bool> SendCustomization(CustomizationData cust);
		

        //Task StartMonitoringNodes();
        Task<bool> SendState(INode node, object obj);
    }
}
