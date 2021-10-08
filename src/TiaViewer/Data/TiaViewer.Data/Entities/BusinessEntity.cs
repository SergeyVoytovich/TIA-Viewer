using System;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    public class BusinessEntity
    {
        [XmlElement(ElementName = "graph")]
        public GraphEntity Graph { get; set; }
    }
}
