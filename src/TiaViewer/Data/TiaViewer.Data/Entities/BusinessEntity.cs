using System;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    /// <summary>
    /// Business entity
    /// </summary>
    [Serializable]
    public class BusinessEntity
    {
        /// <summary>
        /// Graph
        /// </summary>
        [XmlElement(ElementName = "graph")]
        public GraphEntity Graph { get; set; }
    }
}
