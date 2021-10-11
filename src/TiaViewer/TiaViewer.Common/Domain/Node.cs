using System.Collections.Generic;

namespace TiaViewer.Common.Domain
{
    /// <summary>
    /// Node
    /// </summary>
    public class Node : INode
    {
        /// <summary>
        /// Node type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Noe properties
        /// </summary>
        public IDictionary<string, string> Properties { get; set; }
    }
}
