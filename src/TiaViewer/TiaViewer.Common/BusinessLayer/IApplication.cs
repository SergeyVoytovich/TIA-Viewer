using System.Collections.Generic;
using System.Threading.Tasks;
using TiaViewer.Common.Domain;

namespace TiaViewer.Common.BusinessLayer
{
    /// <summary>
    /// Application
    /// </summary>
    /// <remarks>Provided enter point into the business logic</remarks>
    public interface IApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<IList<INode>> GetNodesAsync(string filePath);
    }
}
