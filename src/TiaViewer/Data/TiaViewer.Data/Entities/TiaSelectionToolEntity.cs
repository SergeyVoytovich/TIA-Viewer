using System;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]

    internal class TiaSelectionToolEntity
    {
        [XmlElement(ElementName = "business")]
        public BusinessEntity Business { get; set; }
    }
}
