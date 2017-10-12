using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace homeautomation.Views
{
    public partial class MyMasterView : MasterDetailPage
    {
       

        public MyMasterView()
        {
            InitializeComponent();


            containerPage.ListView.ItemSelected += (sender, e) => {
                var cnt = e.SelectedItem as Interfaces.INodeContainer;
                if (cnt != null)
                {
                    Detail = new NavigationPage(new NodeListView(cnt));
                    containerPage.ListView.SelectedItem = null;
                    IsPresented = true;
                }
            };
        }

       
    }
}
