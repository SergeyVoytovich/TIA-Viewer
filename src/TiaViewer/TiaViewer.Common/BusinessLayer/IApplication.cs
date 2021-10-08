using System.Collections.Generic;
using System.Threading.Tasks;
using TiaViewer.Common.Domain;

namespace TiaViewer.Common.BusinessLayer
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
