using System;
namespace homeautomation.Interfaces
{
    public interface INode// : Xamarin.Forms.Pages.IDataItem
    {
        void Parse(IDataNode node);
        string Name { get; set; }
        //string Type { get; set; }
        string Topic { get; set; }
        string Description { get; set; }
        string StringRepresentation { get; }
        //object State { get; set; }
        //object RawData { get; set; }
        string[] Features { get; set; }
        bool WaitingForChange { get; set; }

        Type GetViewType();
    }

    public interface IDataNode {
		string Name { get; set; }
		//string Type { get; set; }
		string Topic { get; set; }
		string Description { get; set; }
		object State { get; set; }
		//object RawData { get; set; }
		string[] Features { get; set; }
    }
}
