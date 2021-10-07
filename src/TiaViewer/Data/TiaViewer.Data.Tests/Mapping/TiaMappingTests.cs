using System.Collections.Generic;
using TiaViewer.Common.Domain;
using Xunit;
using TiaViewer.Data.Entities;
using TiaViewer.Data.Mapping;
using System.Linq;
using FluentAssertions;

namespace TiaViewer.Data.Tests.Mapping
{
    public class TiaMappingTests
    {
        public static IEnumerable<object[]> MapData => new List<object[]>
        {
            new object[]
            {
                "Type",
                new Dictionary<string, string>
                {
                    {"key", "value" }
                }
            }
        };

        [Theory]
        [MemberData(nameof(MapData))]
        public void Map(string type, IDictionary<string, string> properties)
        {
            // Prepare
            var mapper = MapperFactory.Init();

            // Action
            var actual = mapper.Map<NodeEntity, INode>(new NodeEntity
            {
                Type = type,
                Properties = properties.Select(p => new PropertyEntity
                {
                    Key = p.Key, Value = p.Value
                }).ToList()
            });

            // Asserts
            actual.Should()
                .NotBeNull()
                .And.Match<INode>(n => string.Equals(n.Type, type, System.StringComparison.OrdinalIgnoreCase))
                .And.Match<INode>(n => n.Properties.All(kvp => properties.ContainsKey(kvp.Key) && properties[kvp.Key] == kvp.Value))
                ;

        }
    }
}
