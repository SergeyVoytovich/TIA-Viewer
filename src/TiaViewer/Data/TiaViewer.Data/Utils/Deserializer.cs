using System.IO;
using System.Xml.Serialization;
using TiaViewer.Data.Entities;

namespace TiaViewer.Data.Utils
{
    /// <summary>
    /// Deserializer
    /// </summary>
    internal class Deserializer : IDeserializer
    {
        /// <summary>
        /// Deserialize from file
        /// </summary>
        /// <param name="filePath">Source file path</param>
        /// <returns>Tia root eentitylement</returns>
        public TiaSelectionToolEntity Deserialize(string filePath)
        {
            using var reader = new FileStream(filePath, FileMode.Open);
            return Deserialize(reader);
        }

        /// <summary>
        /// Deserialize from stram
        /// </summary>
        /// <param name="reader">Source stram</param>
        /// <returns>Tia root entity</returns>
        internal virtual TiaSelectionToolEntity Deserialize(Stream reader)
            => Deserialize(new XmlSerializer(typeof(TiaSelectionToolEntity)), reader);

        /// <summary>
        /// Deserialize from serializer and stream
        /// </summary>
        /// <param name="serializer">Xml-serializer</param>
        /// <param name="reader">Source stram</param>
        /// <returns>Tia root entity</returns>
        internal virtual TiaSelectionToolEntity Deserialize(XmlSerializer serializer, Stream reader)
            => serializer.Deserialize(reader) as TiaSelectionToolEntity;
    }
}
