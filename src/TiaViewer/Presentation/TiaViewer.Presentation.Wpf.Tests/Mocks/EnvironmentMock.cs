using Moq;
using TiaViewer.Common.BusinessLayer;
using TiaViewer.Presentation.Wpf.Services;
using TiaViewer.Presentation.Wpf.ViewModels;

namespace TiaViewer.Presentation.Wpf.Tests.Mocks
{
    public class EnvironmentMock : Mock<IViewModelEnvironment>
    {
        public Mock<IApplication> Application { get; set; } = new Mock<IApplication>();
        public Mock<IServicesCollection> Services { get; set; } = new Mock<IServicesCollection>();

        protected override object OnGetObject()
        {
            Setup(e => e.Application).Returns(Application.Object);
            Setup(e => e.Services).Returns(Services.Object);
            return base.OnGetObject();
        }
    }
}