using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using homeautomation.DataModel;
using Xamarin.Forms;

namespace homeautomation.Views.NodeViews
{
    public partial class BrightnessNodeView : BaseNodeContentView
    {
        

        private int lastValue;

        private Task updateTask;

        void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            lastValue = (int)e.NewValue;
            if (updateTask == null || updateTask.IsCompleted)
            {
                updateTask = Task.Delay(400).ContinueWith(task =>
                {
                    var n = Node as BrightnessNode;
                    if (n != null)
                        n.SetBrightness.Execute(lastValue);
                    //task.();
                });
            }
        }

        public BrightnessNodeView()
        {
            InitializeComponent();
        }
    }
}
