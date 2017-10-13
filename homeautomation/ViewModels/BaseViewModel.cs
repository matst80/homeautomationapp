using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using homeautomation.BL;
using homeautomation.DataModel;
using homeautomation.Interfaces;
using Xamarin.Forms;

namespace homeautomation.ViewModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class BaseViewModel
    {
        private ObservableCollection<Interfaces.INode> _nodeList;

        public BaseViewModel()
        {
            _nodeList = Helpers.StateHelper.Instance.NodeStore.Nodes;
        }

        public void SetSourceContainer(INodeContainer container)
        {
            _nodeList = container.Nodes;
            Title = container.Title;
        }

        public string Title
        {
            get;
            set;
        } = "Homeninja";
        /*
        public Xamarin.Forms.Pages.IDataSource NodesDataSource {
            get {
                return Helpers.StateHelper.Instance.NodeStore.NodesDataSource;
            }
        }

        public ObservableCollection<Interfaces.INode> Nodes {
            get {
                return _nodeList;
            }
        }
        */

        public ObservableCollection<Interfaces.INodeContainer> Containers => Helpers.StateHelper.Instance.NodeStore.Containers;


        public void OnAppearing()
        {
            //try {
            var cmd = new Command(async () => await Helpers.StateHelper.Instance.ConnectAsync());
            cmd.Execute(null);
        }
    }
}
