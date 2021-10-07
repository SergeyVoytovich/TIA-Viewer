using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    internal class Graph
    {
        [XmlElement(ElementName = "nodes")]
        public IList<Node> Nodes { get; set; }
    }
}
