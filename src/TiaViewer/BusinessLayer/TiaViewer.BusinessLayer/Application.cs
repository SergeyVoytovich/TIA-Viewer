using System.Collections.Generic;
using System.Threading.Tasks;
using TiaViewer.Common.BusinessLayer;
using TiaViewer.Common.Domain;

namespace TiaViewer.BusinessLayer
{
    public class Application : IApplication
    {
        public Task<IList<INode>> GetNodesAsync(string filePath)
        {
            throw new System.NotImplementedException();
        }
    }
}
