namespace homeautomation.Helpers
{
    public class NodeViewAttribute : System.Attribute
    {
        public NodeViewAttribute(string nodeType) {
            NodeType = nodeType;
        }
        public string NodeType { get; set; }
    }
}