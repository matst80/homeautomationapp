using System;
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
    }
}
