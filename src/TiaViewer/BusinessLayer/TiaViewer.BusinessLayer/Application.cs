using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiaViewer.Common.BusinessLayer;
using TiaViewer.Common.Data;
using TiaViewer.Common.Domain;

namespace TiaViewer.BusinessLayer
{
    public class Application : IApplication
    {
        #region Fields

        private readonly IDataSource _dataSource;

        #endregion


        #region Constructors

        public Application(IDataSource dataSource)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        }

        #endregion


        #region Methods

        public Task<IList<INode>> GetNodesAsync(string filePath)
            => GetNodesAsync(_dataSource.GetRepository(filePath));

        internal virtual async Task<IList<INode>> GetNodesAsync(IRepository repository)
            => repository is null ? new List<INode>() : await repository.GetNodesAsync();

        #endregion
    }
}
