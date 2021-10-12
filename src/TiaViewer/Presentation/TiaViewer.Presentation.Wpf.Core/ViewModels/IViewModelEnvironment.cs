using TiaViewer.Common.BusinessLayer;
using TiaViewer.Presentation.Wpf.Services;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    /// <summary>
    /// View model environment
    /// </summary>
    /// <remarks>Provided all models, services and other dependencies for view models</remarks>
    public interface IViewModelEnvironment
    {
        /// <summary>
        /// Application
        /// </summary>
        public IApplication Application { get; }

        /// <summary>
        /// Services
        /// </summary>
        public IServicesCollection Services { get; }
    }
}