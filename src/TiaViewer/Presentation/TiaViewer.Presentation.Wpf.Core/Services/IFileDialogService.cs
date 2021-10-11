namespace TiaViewer.Presentation.Wpf.Services
{
    public interface IFileDialogService
    {
        bool Show(out string filePath);
    }
}