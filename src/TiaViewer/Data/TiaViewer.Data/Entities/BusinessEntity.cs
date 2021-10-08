using System;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    internal class BusinessEntity
    {
        [XmlElement(ElementName = "graph")]
        public GraphEntity Graph { get; set; }
    }
}
