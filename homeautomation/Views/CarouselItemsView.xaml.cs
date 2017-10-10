using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace homeautomation.Views
{
    public partial class CarouselItemsView : ContentPage
    {
		private ViewModels.BaseViewModel MyViewModel = new ViewModels.BaseViewModel();

	

		protected override void OnAppearing()
		{
            //var a = new Xamarin.Forms.CarouselView();
			base.OnAppearing();
			
			MyViewModel.OnAppearing();
		}

        public CarouselItemsView()
        {
            InitializeComponent();
            BindingContext = MyViewModel;
        }
    }
}
