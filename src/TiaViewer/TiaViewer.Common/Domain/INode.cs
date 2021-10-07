using System.Collections.Generic;

namespace TiaViewer.Common.Domain
{
    /// <summary>
    /// Node
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Note type
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Properties
        /// </summary>
        IDictionary<string, string> Properties { get; set; }
    }
}
