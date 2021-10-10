using TiaViewer.BusinessLayer;
using TiaViewer.Common.BusinessLayer;
using TiaViewer.Common.Data;
using TiaViewer.Data;

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
            _application = application;
        }

        #endregion


        #region Properties

        public MainViewModel Main => new MainViewModel(_application);

        #endregion
    }
}