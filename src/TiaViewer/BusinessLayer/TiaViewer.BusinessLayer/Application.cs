using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiaViewer.Common.BusinessLayer;
using TiaViewer.Common.Data;
using TiaViewer.Common.Domain;

namespace TiaViewer.BusinessLayer
{
    /// <summary>
    /// Domain application
    /// </summary>
    public class Application : IApplication
    {
        #region Fields

        private readonly IDataSource _dataSource;

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="dataSource"></param>
        public Application(IDataSource dataSource)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        }

        #endregion


        #region Methods

        /// <summary>
        /// Get nodes from file
        /// </summary>
        /// <param name="filePath">Source file path</param>
        /// <returns>List of nodes</returns>
        public Task<IList<INode>> GetNodesAsync(string filePath)
            => GetNodesAsync(_dataSource.GetRepository(filePath));

        /// <summary>
        /// Get nodes from repository
        /// </summary>
        /// <param name="repository">Repository</param>
        /// <returns>List of nodes</returns>
        internal virtual async Task<IList<INode>> GetNodesAsync(IRepository repository)
            => repository is null ? new List<INode>() : await repository.GetNodesAsync();

        #endregion
    }
}
