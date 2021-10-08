using System.IO;
using System.Xml.Serialization;
using TiaViewer.Data.Entities;

namespace TiaViewer.Data.Utils
{
    internal class Deserializer : IDeserializer
    {
        public TiaSelectionToolEntity Deserialize(string filePath)
        {
            using var reader = new FileStream(filePath, FileMode.Open);
            return Deserialize(reader);
        }

        internal virtual TiaSelectionToolEntity Deserialize(Stream reader)
            => Deserialize(new XmlSerializer(typeof(TiaSelectionToolEntity)), reader);

        internal virtual TiaSelectionToolEntity Deserialize(XmlSerializer serializer, Stream reader)
            => serializer.Deserialize(reader) as TiaSelectionToolEntity;
    }
}
