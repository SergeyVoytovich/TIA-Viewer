using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
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
                "                           <value>Key</value>" +
                "                       </property>" +
                "                   </properties>" +
                "               </node>" +
                "           </nodes>" +
                "       </graph>" +
                "   </business>" +
                "</tiaselectiontool>",
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
                "</tiaselectiontool>"


            }
        };

        [Theory]
        [MemberData(nameof(DeserializeByStreamAsyncData))]
        public void Deserialize_ByStreamAsync(string xml)
        {
            // Prepare
            using var stream = new MemoryStream(Encoding.ASCII.GetBytes(xml));
            var deserializer = new Deserializer();

            // Action
            var actual = deserializer.Deserialize(stream);

            // Asserts
            actual.Should().NotBeNull();
        }
    }
}
