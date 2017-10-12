using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace homeautomation.Interfaces
{
    public interface INodeContainer {

        void Parse(DataModel.DataNodeContainer data);

        string Title { get; set; }
        string Id { get; set; }

        ObservableCollection<INode> Nodes
        {
            get;
        }    
    }

    public interface INode// : Xamarin.Forms.Pages.IDataItem
    {
        void Parse(DataModel.DataNode node);
        string Name { get; set; }
        //string Type { get; set; }
        string Topic { get; set; }
        string Description { get; set; }
        string StringRepresentation { get; }
        //object State { get; set; }
        //object RawData { get; set; }
        string[] Features { get; set; }
        bool WaitingForChange { get; set; }
        Color BackgroundColor { get; set; }

        Type GetViewType();
    }
    /*
    public interface IDataNode {
		string Name { get; set; }
		//string Type { get; set; }
		string Topic { get; set; }
		string Description { get; set; }
		object State { get; set; }
		//object RawData { get; set; }
		string[] Features { get; set; }
    }*/
}
