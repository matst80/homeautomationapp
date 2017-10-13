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

        public override void Draw(CoreGraphics.CGRect rect)
        {
       
            SetupShadowLayer();
            base.Draw(rect);
        }

        void SetupShadowLayer()
        {
            var glayer = new CALayer();
            glayer.Frame = Bounds;
            glayer.ShadowOffset = CGSize.Empty;
            glayer.ShadowRadius = 10f;
            glayer.ShadowColor = UIColor.LightGray.CGColor;
            Layer.InsertSublayer(glayer,0);
            /*Layer.CornerRadius = 1; // 5 Default

            Layer.ShadowRadius = 10; // 5 Default
            Layer.ShadowColor = UIColor.Gray.CGColor;
            Layer.ShadowOpacity = 0.4f; // 0.8f Default
            Layer.ShadowOffset = new CGSize(1f, 1f);
            //Layer.sh
            var el = Element as NodeSelectorView;

            Layer.BorderColor = UIColor.LightGray.CGColor;
            Layer.BorderWidth = 0.3f;
            Layer.InsertSublayer();

            Layer.RasterizationScale = UIScreen.MainScreen.Scale;
            Layer.ShouldRasterize = true;*/
        }
    }

}
