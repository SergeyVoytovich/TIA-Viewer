using System.Collections.Generic;

namespace TiaViewer.Common.Domain
{
    public class Node : INode
    {
        public string Type { get; set; }
        public IDictionary<string, string> Properties { get; set; }
    }
}
