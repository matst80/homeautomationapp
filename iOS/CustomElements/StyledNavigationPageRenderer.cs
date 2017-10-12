using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(homeautomation.StyledNavigationPage), typeof(homeautomation.StyledNavigationPageRenderer))]
//[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(homeautomation.StyledMasterDetailPageRenderer))]

namespace homeautomation
{
    public class StyledMasterDetailPageRenderer : PhoneMasterDetailRenderer {

        public StyledMasterDetailPageRenderer()
        {
            //this.NavigationController.Toolbar.Translucent = true;
        }

        public override void ViewDidLoad()  
        {  
            base.ViewDidLoad();

            UINavigationBar.Appearance.Translucent = true;
            //UINavigationBar.Appearance.TintColor = UIColor.White;
            //UINavigationBar.Appearance.
            //UINavigationBar.Appearance.
            //UINavigationBar.Appearance.
            //UINavigationBar.Appearance.SetBackgroundImage(ImageHelper.GetGradient(new CGRect(0,0,400,80)), UIBarMetrics.Default); 
              
        }  
    }
    public class ImageHelper
    {
        public static UIColor PrimaryColor = new UIColor(red: 0.40f, green: 0.80f, blue: 0.96f, alpha: 1f);
        private static UIColor SecondaryColor = new UIColor(red: 0.16f, green: 0.50f, blue: 0.73f, alpha: 1f);

        public static UIImage GetGradient(CGRect area)
        {
            var gradient = new CAGradientLayer();  
            gradient.Frame = area;  
            gradient.NeedsDisplayOnBoundsChange = true;  
            gradient.MasksToBounds = true;
            gradient.StartPoint = new CGPoint(0, 0);
            gradient.EndPoint = new CGPoint(1, 0);
            gradient.Colors = new CGColor[] { PrimaryColor.CGColor, SecondaryColor.CGColor };  
            UIGraphics.BeginImageContext(gradient.Bounds.Size);  
            gradient.RenderInContext(UIGraphics.GetCurrentContext());  
            UIImage backImage = UIGraphics.GetImageFromCurrentImageContext();  
            UIGraphics.EndImageContext();
            return backImage;
        }
    }

    public class StyledNavigationPageRenderer : NavigationRenderer
    {
        public StyledNavigationPageRenderer()
        {
            //this.NavigationBarHidden = true;
           
            NavigationBar.Translucent = true;

        }

     

        public override void ViewDidLoad()  
        {  
            base.ViewDidLoad();  

            //UINavigationBar.Appearance.SetBackgroundImage(ImageHelper.GetGradient(NavigationBar.Bounds), UIBarMetrics.Default); 
              
        }  
    }
}
