using System;
using TiaViewer.Common.BusinessLayer;
using TiaViewer.Presentation.Wpf.Services;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    /// <summary>
    /// View model environment
    /// </summary>
    /// <remarks>Provided all models, services and other dependencies for view models</remarks>
    public class ViewModelEnvironment : IViewModelEnvironment
    {
        #region Properties

        /// <summary>
        /// Application
        /// </summary>
        public IApplication Application { get; }

        /// <summary>
        /// Services
        /// </summary>
        public IServicesCollection Services { get; }

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="application">The application</param>
        /// <param name="services">Services collection</param>
        public ViewModelEnvironment(IApplication application, IServicesCollection services)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        #endregion
    }
}