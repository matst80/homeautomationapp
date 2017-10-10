using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(homeautomation.StyledNavigationPage), typeof(homeautomation.StyledNavigationPageRenderer))]

namespace homeautomation
{
    
    public class StyledNavigationPageRenderer : NavigationRenderer
    {
        public StyledNavigationPageRenderer()
        {
            this.NavigationBarHidden = true;
           // NavigationBar.Translucent = true;
            NavigationBar.Translucent = true;
            NavigationBar.BarStyle = UIBarStyle.BlackOpaque;
        }

        private UIColor primaryColor = new UIColor(red: 0.40f, green: 0.80f, blue: 0.96f, alpha: 1f);
        private UIColor secondaryColor = new UIColor(red: 0.16f, green: 0.50f, blue: 0.73f, alpha: 1f);

        public override void ViewDidLoad()  
        {  
            base.ViewDidLoad();  
            var gradient = new CAGradientLayer();  
            gradient.Frame = NavigationBar.Bounds;  
            gradient.NeedsDisplayOnBoundsChange = true;  
            gradient.MasksToBounds = true;
            gradient.StartPoint = new CGPoint(0, 0);
            gradient.EndPoint = new CGPoint(1, 0);
            View.BackgroundColor = new UIColor(red: 0.17f, green: 0.24f, blue: 0.31f, alpha: 1.0f);  
            gradient.Colors = new CGColor[] { primaryColor.CGColor, secondaryColor.CGColor };  
            UIGraphics.BeginImageContext(gradient.Bounds.Size);  
            gradient.RenderInContext(UIGraphics.GetCurrentContext());  
            UIImage backImage = UIGraphics.GetImageFromCurrentImageContext();  
            UIGraphics.EndImageContext();  
            UINavigationBar.Appearance.SetBackgroundImage(backImage, UIBarMetrics.Default); 
              
        }  
    }
}
