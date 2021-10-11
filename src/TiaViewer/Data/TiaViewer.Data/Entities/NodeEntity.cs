using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    public class NodeEntity
    {
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<PropertyEntity> Properties { get; set; }
    }
}
