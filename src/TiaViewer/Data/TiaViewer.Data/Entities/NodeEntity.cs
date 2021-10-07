using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    internal class NodeEntity
    {
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "properties")]
        public IList<PropertyEntity> Properties { get; set; }
    }
}
