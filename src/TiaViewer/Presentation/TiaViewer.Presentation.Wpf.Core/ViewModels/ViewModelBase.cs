using System;
using TiaViewer.Common.BusinessLayer;
using TiaViewer.Presentation.Wpf.Services;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    /// <summary>
    /// Base view model
    /// </summary>
    public abstract class ViewModelBase : NotifyChangedBase
    {
        #region Properties

        /// <summary>
        /// Application
        /// </summary>
        protected IApplication Application { get; }

        /// <summary>
        /// Services
        /// </summary>
        protected IServicesCollection Services { get; }

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="environment">View model environment</param>
        protected ViewModelBase(IViewModelEnvironment environment)
        {
            Application = environment?.Application ?? throw new ArgumentNullException(nameof(IViewModelEnvironment.Application));
            Services = environment.Services ?? throw new ArgumentNullException(nameof(IViewModelEnvironment.Services));
        }

        #endregion
    }
}