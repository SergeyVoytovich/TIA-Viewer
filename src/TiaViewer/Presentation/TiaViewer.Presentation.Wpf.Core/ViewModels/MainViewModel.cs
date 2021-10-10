using TiaViewer.Common.BusinessLayer;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        public string SelectedFile { get => Get<string>(); set => Set(value); }

        #endregion


        #region Constructors

        public MainViewModel() : this(null)
        {
        }

        public MainViewModel(IApplication application) : base(application)
        {
        }

        #endregion
    }
}