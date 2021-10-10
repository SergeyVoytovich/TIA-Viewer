using TiaViewer.Common.BusinessLayer;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    public abstract class ViewModelBase : NotifyChangedBase
    {
        #region Properties

        protected internal IApplication Application { get; }

        #endregion


        #region Constructors

        protected ViewModelBase(IApplication application)
        {
            Application = application;
        }

        #endregion
    }
}