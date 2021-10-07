using System;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]

    internal class TiaSelectionTool
    {
        [XmlElement(ElementName = "business")]
        public Business Business { get; set; }
    }
}
