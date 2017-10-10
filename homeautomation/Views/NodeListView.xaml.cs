using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace homeautomation.Views
{
    public partial class NodeListView : ContentPage
    {
        private ViewModels.BaseViewModel MyViewModel = new ViewModels.BaseViewModel();

        public NodeListView()
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
