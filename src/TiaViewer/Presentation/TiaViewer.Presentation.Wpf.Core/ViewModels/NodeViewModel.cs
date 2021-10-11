namespace TiaViewer.Presentation.Wpf.ViewModels
{
    public class NodeViewModel : ViewModelBase
    {
        #region Properties

        public string Type { get; set; }
        

        #endregion

        public NodeViewModel(ViewModelEnvironment environment) : base(environment)
        {
        }
    }
}