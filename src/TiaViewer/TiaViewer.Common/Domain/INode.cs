namespace TiaViewer.Common.Domain
{
    /// <summary>
    /// Node
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Note type
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Count of properties
        /// </summary>
        int PropertiesCount { get; set; }
    }
}
