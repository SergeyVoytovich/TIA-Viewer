using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using TiaViewer.Common.Domain;
using TiaViewer.Data.Entities;
using TiaViewer.Data.Repositories;
using TiaViewer.Data.Utils;
using Xunit;

namespace TiaViewer.Data.Tests.Repositories
{
    public class FileRepositoryTests
    {
        [Fact]
        public async Task GetNodesAsync()
        {
            // Prepare
            var deserializer = new Mock<IDeserializer>();
            var mapper = new Mock<IMapper>();
            const string filePath = "file.f";
            var repository = new Mock<FileRepository>(filePath, deserializer.Object, mapper.Object) { CallBase = true };
            repository.Setup(r => r.GetNodes()).Returns(new List<INode> { Mock.Of<INode>() });

            // Action
            var actual = await repository.Object.GetNodesAsync();

            // Asserts
            actual.Should().NotBeNullOrEmpty();
            repository.Verify(r => r.GetNodes());
        }

        [Fact]
        public void GetNodes()
        {
            // Prepare
            var deserializer = new Mock<IDeserializer>();
            var entity = new TiaSelectionToolEntity();
            deserializer.Setup(d => d.Deserialize(It.IsAny<string>())).Returns(entity);
            var mapper = new Mock<IMapper>();
            const string filePath = "file.f";
            var repository = new Mock<FileRepository>(filePath, deserializer.Object, mapper.Object) { CallBase = true };
            repository.Setup(r => r.GetNodes(It.IsAny<TiaSelectionToolEntity>())).Returns(new List<INode> { Mock.Of<INode>() });

            // Action
            var actual = repository.Object.GetNodes();

            // Asserts
            actual.Should().NotBeNullOrEmpty();
            repository.Verify(r => r.GetNodes(It.Is<TiaSelectionToolEntity>(e => Equals(e, entity))));
            deserializer.Setup(d => d.Deserialize(It.Is<string>(s => string.Equals(s, filePath, System.StringComparison.OrdinalIgnoreCase)))).Returns(entity);
        }

        [Fact]
        public void GetNodes_Entity()
        {
            // Prepare
            var deserializer = new Mock<IDeserializer>();
            var entity = new TiaSelectionToolEntity();
            var mapper = new Mock<IMapper>();
            const string filePath = "file.f";
            var repository = new Mock<FileRepository>(filePath, deserializer.Object, mapper.Object) { CallBase = true };
            repository.Setup(r => r.GetNodes(It.IsAny<IEnumerable<NodeEntity>>())).Returns(new List<INode> { Mock.Of<INode>() });

            // Action
            var actual = repository.Object.GetNodes(entity);

            // Asserts
            actual.Should().NotBeNullOrEmpty();
            repository.Verify(r => r.GetNodes(It.IsAny<IEnumerable<NodeEntity>>()));
        }

        [Fact]
        public void GetNodes_Nodes_Null()
        {
            // Prepare
            var deserializer = new Mock<IDeserializer>();
            var entity = new TiaSelectionToolEntity();
            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IList<INode>>(It.IsAny<IEnumerable<NodeEntity>>()))
                .Returns(new List<INode> { Mock.Of<INode>() });
            const string filePath = "file.f";
            var repository = new Mock<FileRepository>(filePath, deserializer.Object, mapper.Object) { CallBase = true };

            // Action
            var actual = repository.Object.GetNodes(null as IEnumerable<NodeEntity>);

            // Asserts
            actual.Should()
                .NotBeNull()
                .And.BeEmpty();
            mapper.Verify(m => m.Map<IList<INode>>(It.IsAny<IEnumerable<NodeEntity>>()), Times.Never);
        }

        [Fact]
        public void GetNodes_Nodes()
        {
            // Prepare
            var deserializer = new Mock<IDeserializer>();
            var entity = new TiaSelectionToolEntity();
            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IList<INode>>(It.IsAny<IEnumerable<NodeEntity>>()))
                .Returns(new List<INode> { Mock.Of<INode>() });
            const string filePath = "file.f";
            var repository = new Mock<FileRepository>(filePath, deserializer.Object, mapper.Object) { CallBase = true };

            // Action
            var actual = repository.Object.GetNodes(new List<NodeEntity> { new NodeEntity() });

            // Asserts
            actual.Should().NotBeNullOrEmpty();
            mapper.Verify(m => m.Map<IList<INode>>(It.IsAny<IEnumerable<NodeEntity>>()));
        }
    }
}
