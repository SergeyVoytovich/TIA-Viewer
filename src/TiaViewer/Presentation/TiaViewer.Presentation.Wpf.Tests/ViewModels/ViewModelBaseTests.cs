using FluentAssertions;
using Moq;
using TiaViewer.Presentation.Wpf.Tests.Mocks;
using TiaViewer.Presentation.Wpf.ViewModels;
using Xunit;

namespace TiaViewer.Presentation.Wpf.Tests.ViewModels
{
    public class ViewModelBaseTests
    {
        [Fact]
        public void Ctor()
        {
            // Prepare
            var viewModel = new Mock<ViewModelBase>(new EnvironmentMock().Object) {CallBase = true};

            // Action
            var instance = viewModel.Object;

            // Asserts
            instance.Should().NotBeNull();
        }
    }
}