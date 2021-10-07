using System;
using System.Runtime.CompilerServices;
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
