namespace TiaViewer.Presentation.Wpf.Services
{
    /// <summary>
    /// Collection of the presentation services
    /// </summary>
    public interface IServicesCollection
    {
        /// <summary>
        /// File dialog service
        /// </summary>
        IFileDialogService FileDialog { get; }
    }
}