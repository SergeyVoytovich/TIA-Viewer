using Microsoft.Win32;

namespace TiaViewer.Presentation.Wpf.Services
{
    /// <summary>
    /// File dialog service
    /// </summary>
    public class FileDialogService : IFileDialogService
    {
        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="filePath">Selected file path if dialog successfully closed</param>
        /// <returns>Dialog result</returns>
        public bool Show(out string filePath)
        {
            var dialog = new OpenFileDialog();
            var dialogResult = dialog.ShowDialog() ?? false;

            filePath = dialogResult ? dialog.FileName : string.Empty;
            return dialogResult;
        }
    }
}