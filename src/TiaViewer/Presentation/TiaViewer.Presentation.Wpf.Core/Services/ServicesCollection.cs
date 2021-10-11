using System;

namespace TiaViewer.Presentation.Wpf.Services
{
    /// <summary>
    /// Services collection
    /// </summary>
    public class ServicesCollection : IServicesCollection
    {
        /// <summary>
        /// File dialog service
        /// </summary>
        public IFileDialogService FileDialog { get; }

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="fileDialog">File dialog service</param>
        public ServicesCollection(IFileDialogService fileDialog)
        {
            FileDialog = fileDialog ?? throw new ArgumentNullException(nameof(fileDialog));
        }

      
    }
}