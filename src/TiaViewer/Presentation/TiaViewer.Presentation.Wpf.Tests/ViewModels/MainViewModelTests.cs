using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TiaViewer.Common.Domain;
using TiaViewer.Presentation.Wpf.Tests.Mocks;
using TiaViewer.Presentation.Wpf.ViewModels;
using Xunit;

namespace TiaViewer.Presentation.Wpf.Tests.ViewModels
{
    public class MainViewModelTests
    {
        [Fact]
        public async Task OpenFileAsync()
        {
            // Prepare
            const string sourceFilePath = "C:\\file.f";
            var environment = new EnvironmentMock();
            var file = sourceFilePath;
            environment.Services.Setup(s => s.FileDialog.Show(out file))
                .Callback(() => { file = sourceFilePath; })
                .Returns(true);

            var viewModel = new Mock<MainViewModel>(environment.Object) { CallBase = true };
            viewModel.Setup(v => v.LoadNodesAsync(It.IsAny<string>())).Returns(Task.CompletedTask);

            // Action
            await viewModel.Object.OpenFileAsync();

            // Asserts
            viewModel.Object.SelectedFile.Should().Be("file.f");
            viewModel.Verify(v => v.LoadNodesAsync(It.Is<string>(s => string.Equals(s, sourceFilePath, StringComparison.OrdinalIgnoreCase))));
            environment.Services.Verify(s => s.FileDialog.Show(out file));
        }

        [Fact]
        public async Task OpenFileAsync_DialogIsFalse()
        {
            // Prepare
            const string sourceFilePath = "C:\\file.f";
            var environment = new EnvironmentMock();
            var file = sourceFilePath;
            environment.Services.Setup(s => s.FileDialog.Show(out file))
                .Callback(() => { file = sourceFilePath; })
                .Returns(false);

            var viewModel = new Mock<MainViewModel>(environment.Object) { CallBase = true };
            viewModel.Setup(v => v.LoadNodesAsync(It.IsAny<string>())).Returns(Task.CompletedTask);

            // Action
            await viewModel.Object.OpenFileAsync();

            // Asserts
            viewModel.Object.SelectedFile.Should().BeNull();
            viewModel.Verify(v => v.LoadNodesAsync(It.IsAny<string>()), Times.Never);
            environment.Services.Verify(s => s.FileDialog.Show(out file));
        }

        [Fact]
        public async Task LoadNodesAsync()
        {
            // Prepare
            const string sourceFilePath = "C:\\file.f";
            var environment = new EnvironmentMock();
            var nodes = new List<INode> { Mock.Of<INode>() };
            environment.Application
                .Setup(a => a.GetNodesAsync(It.IsAny<string>()))
                .ReturnsAsync(nodes);
            var viewModel = new Mock<MainViewModel>(environment.Object) { CallBase = true };
            viewModel.Setup(v => v.DisplayNodes(It.IsAny<IEnumerable<INode>>()));

            // Action
            await viewModel.Object.LoadNodesAsync(sourceFilePath);

            // Asserts
            environment.Application
                .Verify(a => a.GetNodesAsync(It.Is<string>(s => string.Equals(s, sourceFilePath, StringComparison.OrdinalIgnoreCase))));
            viewModel.Verify(v => v.DisplayNodes(It.Is<IEnumerable<INode>>(n => Equals(n, nodes))));
        }

        [Fact]
        public void DisplayNodes()
        {
            // Prepare
            var environment = new EnvironmentMock();
            var viewModel = new Mock<MainViewModel>(environment.Object) { CallBase = true };
            var node = new Node
            {
                Type = nameof(INode.Type),
                Properties = new Dictionary<string, string>
                {
                    {nameof(NodeViewModel.Name), nameof(NodeViewModel.Name)},
                    {nameof(NodeViewModel.Id), nameof(NodeViewModel.Id)},
                    {nameof(INode.Properties), nameof(INode.Properties)},
                }
            };

            // Action
            viewModel.Object.DisplayNodes(new List<INode> {node});

            // Asserts
            viewModel.Object.Nodes.Should()
                .NotBeNullOrEmpty()
                .And.HaveCount(1);
            viewModel.Object.Nodes.First().Should()
                .Match<NodeViewModel>(n => string.Equals(n.Type, node.Type));
            viewModel.Object.Nodes.First().Should()
                .Match<NodeViewModel>(n => string.Equals(n.Id, nameof(NodeViewModel.Id)));
            viewModel.Object.Nodes.First().Should()
                .Match<NodeViewModel>(n => string.Equals(n.Name, nameof(NodeViewModel.Name)));
            viewModel.Object.Nodes.First().Properties.Should()
                .NotBeNullOrEmpty()
                .And.HaveCount(3);
        }
    }
}