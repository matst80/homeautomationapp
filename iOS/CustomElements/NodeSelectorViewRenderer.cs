using System;
using CoreAnimation;
using CoreGraphics;
using homeautomation.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(homeautomation.Views.NodeSelectorView), typeof(homeautomation.NodeSelectorViewRenderer))]

namespace homeautomation
{
    public class NodeSelectorViewRenderer : ViewRenderer<NodeSelectorView,UIControl>
    {
        public NodeSelectorViewRenderer()
        {
        }

       

        protected override void OnElementChanged(ElementChangedEventArgs<NodeSelectorView> e)
        {
            SetupShadowLayer();
            base.OnElementChanged(e);
        }

        void SetupShadowLayer()
        {
            var bgColor = new UIColor(red: 0.17f, green: 0.24f, blue: 0.31f, alpha: 1.0f);
            /*
            var glayer = new CAShapeLayer();
            glayer.Frame = Bounds.Inset(1,1);
            glayer.ShadowOffset = new CGSize(0, 0);
            glayer.ShadowOpacity = 0.4f;
            //glayer.ShadowRadius = 10f;
            glayer.ShadowColor = bgColor.CGColor;
            glayer.MasksToBounds = true;
            Layer.BackgroundColor = UIColor.White.CGColor;
            
            var path = new CGPath();


            var offsetInner = 0;
            var offsetOuter = 4;


            path.MoveToPoint(new CGPoint(Bounds.Left+offsetInner, Bounds.Bottom-offsetInner));
            path.AddLineToPoint(new CGPoint(Bounds.Right - offsetInner, Bounds.Bottom - offsetInner));
            path.AddLineToPoint(new CGPoint(Bounds.Right - offsetInner, Bounds.Top + offsetInner));
            path.AddLineToPoint(new CGPoint(Bounds.Left + offsetInner, Bounds.Top + offsetInner));
            path.CloseSubpath();

            path.MoveToPoint(new CGPoint(Bounds.Left - offsetOuter,Bounds.Top - offsetOuter));
            path.AddLineToPoint(new CGPoint(Bounds.Right + offsetOuter, Bounds.Top - offsetOuter));
            path.AddLineToPoint(new CGPoint(Bounds.Right + offsetOuter, Bounds.Bottom + offsetOuter));
            path.AddLineToPoint(new CGPoint(Bounds.Left - offsetOuter, Bounds.Bottom + offsetOuter));
            path.CloseSubpath();

            glayer.ShadowRadius = 3;
            glayer.ShadowPath = path;
           
            Layer.AddSublayer(glayer);
            */
            Layer.BackgroundColor = UIColor.White.CGColor;
            Layer.CornerRadius = 3; // 5 Default
            Layer.ShadowOffset = new CGSize(3, 3);
            Layer.ShadowRadius = 4; // 5 Default
            Layer.ShadowColor = UIColor.Black.CGColor;
            Layer.ShadowOpacity = 0.2f; // 0.8f Default

            //Layer.sh
            var el = Element as NodeSelectorView;

            //Layer.BorderColor = UIColor.LightGray.CGColor;
            //Layer.BorderWidth = 0.3f;
            //Layer.InsertSublayer();

            Layer.RasterizationScale = UIScreen.MainScreen.Scale;
            Layer.ShouldRasterize = true;
        }
    }

}
