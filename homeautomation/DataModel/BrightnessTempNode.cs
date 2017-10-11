using System;
using System.Windows.Input;
using homeautomation.Views.NodeViews;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace homeautomation.DataModel
{
    [Helpers.NodeFeature("lighttemp")]
    public class BrightnessTempNode : BrightnessNode
    {
        public BrightnessTempNode()
        {
        }

        public int Temp { get; set; }

        public ICommand SetTemp => new Command((obj) =>
        {
            base.SendState.Execute(obj);
        });

    }


}
