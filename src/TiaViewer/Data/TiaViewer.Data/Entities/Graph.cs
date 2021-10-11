using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    /// <summary>
    /// Graph entity
    /// </summary>
    [Serializable]
    public class GraphEntity
    {
        /// <summary>
        /// Nodes
        /// </summary>
        [XmlArray(ElementName = "nodes")]
        [XmlArrayItem(ElementName = "node")]
        public List<NodeEntity> Nodes { get; set; }
    }
}
