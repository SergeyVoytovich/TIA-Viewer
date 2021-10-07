using System;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    internal class Business
    {
        [XmlElement(ElementName = "graph")]
        public Graph Graph { get; set; }
    }
}
