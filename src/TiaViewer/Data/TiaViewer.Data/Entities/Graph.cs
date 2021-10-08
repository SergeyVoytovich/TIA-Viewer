using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    public class GraphEntity
    {
        [XmlElement(ElementName = "nodes")]
        public List<NodeEntity> Nodes { get; set; }
    }
}
