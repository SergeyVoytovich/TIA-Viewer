using System.Collections.Generic;
using System.Threading.Tasks;
using TiaViewer.Common.Domain;

namespace TiaViewer.Common.Data
{
    /// <summary>
    /// Repository
    /// </summary>
    interface IRepository
    {
        /// <summary>
        /// Get nodes 
        /// </summary>
        /// <returns>List of nodes</returns>
        Task<IList<INode>> GetNodesAsync();
    }
}
