using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    internal class Node
    {
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "properties")]
        public IList<Property> Properties { get; set; }
    }
}
