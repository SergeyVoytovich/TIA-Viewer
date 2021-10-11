using System;
using TiaViewer.BusinessLayer;
using TiaViewer.Common.BusinessLayer;
using TiaViewer.Common.Data;
using TiaViewer.Data;
using TiaViewer.Presentation.Wpf.Services;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    public class ViewModelsFactory
    {
        #region Fields

        private readonly IApplication _application;

        #endregion


        #region Constructors

        public ViewModelsFactory()
            : this(new DataSource())
        {

        }

        public ViewModelsFactory(IDataSource dataSource)
            :this(new Application(dataSource))
        {

        }
        public ViewModelsFactory(IApplication application)
        {
            _application = application ?? throw new ArgumentNullException(nameof(application));
        }

        #endregion


        #region Properties

        public MainViewModel Main => new MainViewModel(new ViewModelEnvironment(_application, new ServicesCollection(new FileDialogService())));

        #endregion
    }
}