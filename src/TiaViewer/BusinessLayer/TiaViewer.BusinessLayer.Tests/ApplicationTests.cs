using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TiaViewer.Common.Data;
using TiaViewer.Common.Domain;
using Xunit;

namespace TiaViewer.BusinessLayer.Tests
{
    public class ApplicationTests
    {
        [Fact]
        public async Task GetNodesAsync_File()
        {
            // Prepare
            var dataSource = new Mock<IDataSource>();
            dataSource.Setup(d => d.GetRepository(It.IsAny<string>())).Returns(Mock.Of<IRepository>());
            var application = new Mock<Application>(dataSource.Object) { CallBase = true };
            application.Setup(a => a.GetNodesAsync(It.IsAny<IRepository>())).ReturnsAsync(new List<INode> { Mock.Of<INode>() });
            const string filePath = "file.f";

            // Action
            var actual = await application.Object.GetNodesAsync(filePath);

            // Asserts
            actual.Should().NotBeNullOrEmpty();
            application.Verify(a => a.GetNodesAsync(It.IsAny<IRepository>()));
            dataSource.Verify(d => d.GetRepository(It.Is<string>(s => string.Equals(s, filePath, StringComparison.OrdinalIgnoreCase))));
        }

        [Fact]
        public async Task GetNodesAsync_Repository()
        {
            // Prepare
            var repository = new Mock<IRepository>();
            repository.Setup(r => r.GetNodesAsync()).ReturnsAsync(new List<INode> { Mock.Of<INode>() });
            var application = new Mock<Application>(Mock.Of<IDataSource>()) { CallBase = true };

            // Action
            var actual = await application.Object.GetNodesAsync(repository.Object);

            // Asserts
            actual.Should().NotBeNullOrEmpty();
            repository.Verify(r => r.GetNodesAsync());
        }
    }
}
