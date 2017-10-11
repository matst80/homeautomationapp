using System;
using System.Collections.Generic;
using homeautomation.BL;
using homeautomation.DataModel;
using homeautomation.Interfaces;
using Xamarin.Forms;

namespace homeautomation.Views.NodeViews
{
    public partial class OnOffNodeView : BaseNodeContentView
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var n = Node as OnOffNode;
            if (n != null)
                n.SendBoolState.Execute(!n.IsPowerdOn);
        }

        /*
        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            
            var n = Node as OnOffNode;
            if (n!=null)
                n.SendBoolState.Execute(e.Value);
        }
        */

        public OnOffNodeView()
        {
            
            InitializeComponent();

        }
    }
}
