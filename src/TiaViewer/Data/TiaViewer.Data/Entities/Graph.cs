using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    public class GraphEntity
    {
        [XmlArray(ElementName = "nodes")]
        [XmlArrayItem(ElementName = "node")]
        public List<NodeEntity> Nodes { get; set; }
    }
}
