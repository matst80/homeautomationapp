using System;

namespace homeautomation.Helpers
{
    public class NodeFeatureAttribute : Attribute
    {
        public NodeFeatureAttribute(string feature) {
            Features = feature;
        }
        public string Features { get; set; }
    }
}