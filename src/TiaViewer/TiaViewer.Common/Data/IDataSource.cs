namespace TiaViewer.Common.Data
{
    /// <summary>
    /// Data source
    /// </summary>
    /// <remarks>Like a repositories factory
    /// </remarks>
    public interface IDataSource
    {
        /// <summary>
        /// Get repository from file
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>Repository</returns>
        IRepository GetRepository(string filePath);
    }
}
