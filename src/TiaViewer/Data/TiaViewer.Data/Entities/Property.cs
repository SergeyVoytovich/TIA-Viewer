using System;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    [Serializable]
    internal class Property
    {
        [XmlElement(ElementName = "key")]
        public string Key { get; set; }

        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }
}
