using System;
using System.Windows.Input;
using homeautomation.Interfaces;
using homeautomation.Views.NodeViews;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace homeautomation.DataModel
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class BaseNode : INode
    {
        
        public string Name { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }

        public string[] Features { get; set; }

        public int Updates { get; set; }

        public string StringRepresentation { get; set; }

        public bool WaitingForChange { get; set; }

        private Type _viewType;
        public virtual Type GetViewType()
        {
            if (_viewType == null)
            {
                _viewType = Helpers.StateHelper.Instance.GetViewType(this);
            }
            return _viewType;
        }

        public ICommand SendState => new Command((obj) =>
        {
            if (!WaitingForChange)
            {
                WaitingForChange = true;
                Helpers.StateHelper.Instance.ApiHandler.SendState(this, obj);
            }
        });



        public virtual void Parse(IDataNode node)
        {
            
            Updates++;
            Name = node.Name;
            if (string.IsNullOrEmpty(Topic))
                Topic = node.Topic;
            Description = node.Description;
            StringRepresentation = node.State.ToString();

            Features = node.Features;
            if (string.IsNullOrEmpty(Topic))
                Topic = "unknown";
            WaitingForChange = false;
                
        }
    }
}
