using System;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    /// <summary>
    /// Root entity
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "tiaselectiontool")]
    public class TiaSelectionToolEntity
    {
        /// <summary>
        /// Business
        /// </summary>
        [XmlElement(ElementName = "business")]
        public BusinessEntity Business { get; set; }
    }
}
