using TiaViewer.Data.Entities;

namespace TiaViewer.Data.Utils
{
    /// <summary>
    /// Deserializer
    /// </summary>
    internal interface IDeserializer
    {
        /// <summary>
        /// Deserialize <see cref="TiaSelectionToolEntity"/> from file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>Deserialized object</returns>
        TiaSelectionToolEntity Deserialize(string filePath);
    }
}
