using System;
using System.Xml.Serialization;

namespace TiaViewer.Data.Entities
{
    /// <summary>
    /// Property entity
    /// </summary>
    [Serializable]
    public class PropertyEntity
    {
        /// <summary>
        /// Key
        /// </summary>
        [XmlElement(ElementName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }
}
