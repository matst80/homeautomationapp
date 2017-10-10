using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using homeautomation.BL;
using homeautomation.DataModel;
using Xamarin.Forms;

namespace homeautomation.ViewModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class BaseViewModel
    {
        public BaseViewModel()
        {
        }

        public string Title
        {
            get;
            set;
        } = "homeautomation";
        /*
        public Xamarin.Forms.Pages.IDataSource NodesDataSource {
            get {
                return Helpers.StateHelper.Instance.NodeStore.NodesDataSource;
            }
        }
*/
        public ObservableCollection<Interfaces.INode> Nodes => Helpers.StateHelper.Instance.NodeStore.Nodes;

        public ICommand DoStuff => new Command((obj) =>
        {
			Device.BeginInvokeOnMainThread(() =>
			{
                foreach (var n in Nodes)
                {
                    n.Name += "..";
                }
            });
        });

        public void OnAppearing()
        {
            
            var cmd = new Command(async () => await Helpers.StateHelper.Instance.ConnectAsync());
            cmd.Execute(null);

        }
    }
}
