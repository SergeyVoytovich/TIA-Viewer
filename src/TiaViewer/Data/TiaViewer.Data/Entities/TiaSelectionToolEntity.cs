using System;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "tiaselectiontool")]
    public class TiaSelectionToolEntity
    {
        [XmlElement(ElementName = "business")]
        public BusinessEntity Business { get; set; }
    }
}
