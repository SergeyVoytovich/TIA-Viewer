using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    internal class GraphEntity
    {
        [XmlElement(ElementName = "nodes")]
        public IList<NodeEntity> Nodes { get; set; }
    }
}
