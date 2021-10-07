using System.Collections.Generic;
using System.Threading.Tasks;
using TiaViewer.Common.Domain;

namespace TiaViewer.Common.Application
{
    /// <summary>
    /// Application
    /// </summary>
    /// <remarks>Provided enter point into the business logic</remarks>
    interface IApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<IList<INode>> GetNodesAsync(string filePath);
    }
}
