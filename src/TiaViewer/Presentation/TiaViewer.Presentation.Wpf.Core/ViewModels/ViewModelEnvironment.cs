using System;
using TiaViewer.Common.BusinessLayer;
using TiaViewer.Presentation.Wpf.Services;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    public class ViewModelEnvironment
    {
        #region Properties

        public IApplication Application { get;}
        public IServicesCollection Services { get; }

        #endregion


        #region Constructors

       public ViewModelEnvironment(IApplication application, IServicesCollection services)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        #endregion
    }
}