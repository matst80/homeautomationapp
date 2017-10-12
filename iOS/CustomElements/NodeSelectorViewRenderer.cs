using System;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(homeautomation.Views.NodeSelectorView), typeof(homeautomation.NodeSelectorViewRenderer))]

namespace homeautomation
{
    public class NodeSelectorViewRenderer : FrameRenderer
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
            Layer.CornerRadius = 1; // 5 Default

            Layer.ShadowRadius = 10; // 5 Default
            Layer.ShadowColor = UIColor.Gray.CGColor;
            Layer.ShadowOpacity = 0.4f; // 0.8f Default
            Layer.ShadowOffset = new CGSize(1f, 1f);
            //Layer.sh
            if (Element.OutlineColor == Xamarin.Forms.Color.Default)
            {
                Layer.BorderColor = UIColor.Clear.CGColor;
            }
            else
            {
                Layer.BorderColor = Element.OutlineColor.ToCGColor();
                Layer.BorderWidth = 0.3f;
            }

            Layer.RasterizationScale = UIScreen.MainScreen.Scale;
            Layer.ShouldRasterize = true;
        }
    }

}
