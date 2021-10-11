using System;
using TiaViewer.Common.BusinessLayer;
using TiaViewer.Presentation.Wpf.Services;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    public abstract class ViewModelBase : NotifyChangedBase
    {
        #region Properties

        protected IApplication Application { get; }
        protected IServicesCollection Services { get; }

        #endregion


        #region Constructors

        protected ViewModelBase(ViewModelEnvironment environment)
        {
            Application = environment?.Application ?? throw new ArgumentNullException(nameof(ViewModelEnvironment.Application));
            Services = environment.Services ?? throw new ArgumentNullException(nameof(ViewModelEnvironment.Services));
        }

        #endregion
    }
}