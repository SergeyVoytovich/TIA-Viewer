namespace TiaViewer.Presentation.Wpf.Services
{
    /// <summary>
    /// File dialog service
    /// </summary>
    public interface IFileDialogService
    {
        /// <summary>
        /// Show file dialog
        /// </summary>
        /// <param name="filePath">Selected file path</param>
        /// <returns>Dialog result</returns>
        bool Show(out string filePath);
    }
}