using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace homeautomation.Views
{
    public partial class ContainerListView : ContentPage
    {
        private ViewModels.BaseViewModel MyViewModel = new ViewModels.BaseViewModel();

        public ListView ListView {
            get {
                return this.lbContainers;
            }
        }


        public ContainerListView()
        {
            InitializeComponent();
            BindingContext = MyViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MyViewModel.OnAppearing();
        }

    }
}
