using Microsoft.Win32;

namespace TiaViewer.Presentation.Wpf.Services
{
    public class FileDialogService : IFileDialogService
    {
        public bool Show(out string filePath)
        {
            var dialog = new OpenFileDialog();
            var dialogResult = dialog.ShowDialog() ?? false;

            filePath = dialogResult ? dialog.FileName : string.Empty;
            return dialogResult;
        }
    }
}