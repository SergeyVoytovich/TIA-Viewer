namespace TiaViewer.Presentation.Wpf.Services
{
    public class ServicesCollection : IServicesCollection
    {
        public ServicesCollection(IFileDialogService fileDialog)
        {
            FileDialog = fileDialog;
        }

        public IFileDialogService FileDialog { get; }
    }
}