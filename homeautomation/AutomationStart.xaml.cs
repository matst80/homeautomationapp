using System;
using System.Collections.Generic;
using homeautomation.Views;
using Xamarin.Forms;

namespace homeautomation
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public partial class AutomationStart : ContentPage
    {
        public AutomationStart()
        {
            InitializeComponent();
            //var l = LeftPane as ContentPresenter;
            //var m = ContentPane as ContentPresenter;
            //l.Content = new NodeListView();
        }
    }
}
