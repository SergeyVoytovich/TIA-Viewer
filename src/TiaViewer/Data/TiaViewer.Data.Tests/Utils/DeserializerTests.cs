using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using TiaViewer.Data.Entities;
using TiaViewer.Data.Utils;
using Xunit;

namespace TiaViewer.Data.Tests.Utils
{
    public class DeserializerTests
    {
        public static IEnumerable<object[]> DeserializeByStreamAsyncData => new List<object[]>
        {
            new object[] 
            {
                "<tiaselectiontool>" +
                "   <business>" +
                "       <graph>" +
                "           <nodes>" +
                "               <node Type=\"Solution\">" +
                "                   <properties>" +
                "                       <property>" +
                "                           <key>Key</key>" +
                "                           <value>Value</value>" +
                "                       </property>" +
                "                   </properties>" +
                "               </node>" +
                "           </nodes>" +
                "       </graph>" +
                "   </business>" +
                "</tiaselectiontool>",
                new List<NodeEntity>
                {
                    new()
                    {
                        Type = "Solution",
                        Properties = new List<PropertyEntity>
                        {
                            new() {Key = "Key", Value = "Value"}
                        }
                    }
                }
            },
            new object[]
            {
                "<tiaselectiontool Version=\"2015.3.9.0\" Application=\"TIA Selection Tool\">" +
                "  <business>" +
                "    <graph>" +
                "      <nodes>" +
                "        <node Type=\"Solution\">" +
                "          <properties>" +
                "            <property>" +
                "              <key>CreationTime</key>" +
                "              <value>635768005256758612</value>" +
                "            </property>" +
                "            <property>" +
                "              <key>LastWriteTime</key>" +
                "              <value>635831296673274407</value>" +
                "            </property>" +
                "            <property>" +
                "              <key>Id</key>" +
                "              <value>QEzaVSJxUjtOJ1hB</value>" +
                "            </property>" +
                "            <property>" +
                "              <key>Name</key>" +
                "              <value>Test1</value>" +
                "            </property>" +
                "          </properties>" +
                "        </node>" +
                "      </nodes>" +
                "    </graph>" +
                "  </business>" +
                "</tiaselectiontool>",
                new List<NodeEntity>
                {
                    new()
                    {
                        Type = "Solution",
                        Properties = new List<PropertyEntity>
                        {
                            new() {Key = "CreationTime", Value = "635768005256758612"},
                            new() {Key = "LastWriteTime", Value = "635831296673274407"},
                            new() {Key = "Id", Value = "QEzaVSJxUjtOJ1hB"},
                            new() {Key = "Name", Value = "Test1"}
                        }
                    }
                }
            }
        };

        [Theory]
        [MemberData(nameof(DeserializeByStreamAsyncData))]
        public void Deserialize_ByStreamAsync_AllObjects(string xml, IList<NodeEntity> nodes)
        {
            // Prepare
            using var stream = new MemoryStream(Encoding.ASCII.GetBytes(xml));
            var deserializer = new Deserializer();

            // Action
            var actual = deserializer.Deserialize(stream);

            // Asserts
            actual.Should().NotBeNull();
            actual.Business.Should().NotBeNull();
            actual.Business.Graph.Should().NotBeNull();
            actual.Business.Graph.Nodes.Should()
                .NotBeNullOrEmpty()
                .And.HaveCount(nodes.Count);
            actual.Business.Graph.Nodes.Should().OnlyContain(n => n.Properties.Any());

            bool Equal(NodeEntity a, NodeEntity b) 
                => string.Equals(a.Type, b.Type, StringComparison.OrdinalIgnoreCase) 
                   && a.Properties.All(
                       ap => b.Properties.Any(
                           p => string.Equals(ap.Key, p.Key, StringComparison.OrdinalIgnoreCase) 
                                && string.Equals(ap.Value, p.Value, StringComparison.OrdinalIgnoreCase))
                       );

            nodes.All(n => actual.Business.Graph.Nodes.Any(a => Equal(a, n))).Should().BeTrue();
        }
    }
}
