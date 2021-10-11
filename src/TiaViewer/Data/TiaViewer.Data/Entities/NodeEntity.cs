using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    /// <summary>
    /// Nodes entity
    /// </summary>
    [Serializable]
    public class NodeEntity
    {
        /// <summary>
        /// Type
        /// </summary>
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        /// <summary>
        /// Properties
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<PropertyEntity> Properties { get; set; }
    }
}
