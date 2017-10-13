using System;
using System.Collections.Generic;
using homeautomation.Interfaces;
using Xamarin.Forms;
using homeautomation.Helpers;

namespace homeautomation.Views
{
    public partial class NodeItemView : ContentPage
    {

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await StateHelper.Instance.ApiHandler.SendCustomization(new DataModel.CustomizationData(CurrentNode,tbName.Text, tbDesc.Text));
            //await App.Current.MainPage.Navigation.PopModalAsync(true);
        }

        public NodeItemView()
        {
            
        }

        public INode CurrentNode
        {
            get;
            set;
        }

        public NodeItemView(INode node) {
            CurrentNode = node;
            InitializeComponent();

            if (CurrentNode != null)
            {
                BindingContext = CurrentNode;
            }

        }
    }
}
