using System;
using Xamarin.Forms;

namespace homeautomation
{
    public class StyledNavigationPage : NavigationPage
    {
        public StyledNavigationPage(Page content) : base(content)
        {
            BarBackgroundColor = Color.White;
        }
    }


}
