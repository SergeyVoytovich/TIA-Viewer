using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TiaViewer.Common.Data;
using TiaViewer.Common.Domain;
using TiaViewer.Data.Entities;
using TiaViewer.Data.Utils;

namespace TiaViewer.Data.Repositories
{
    /// <summary>
    /// File repository
    /// </summary>
    public class FileRepository : IRepository
    {
        #region Fields

        private readonly string _filePath;
        private readonly IDeserializer _deserializer;
        private readonly IMapper _mapper;

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="filePath">Source file path</param>
        /// <param name="deserializer">Deserializer</param>
        /// <param name="mapper">Mapper</param>
        internal FileRepository(string filePath, IDeserializer deserializer, IMapper mapper)
        {
            _filePath = string.IsNullOrWhiteSpace(filePath) ? throw new ArgumentNullException(nameof(filePath)) : filePath;
            _deserializer = deserializer ?? throw new ArgumentNullException(nameof(deserializer));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion


        #region Methods

        /// <summary>
        /// Get nodes
        /// </summary>
        /// <returns>List of nodes</returns>
        public Task<IList<INode>> GetNodesAsync()
            => Task.Run(GetNodes);

        /// <summary>
        /// Get nodes
        /// </summary>
        /// <returns>Nodes</returns>
        internal virtual IList<INode> GetNodes()
            => GetNodes(_deserializer.Deserialize(_filePath));

        /// <summary>
        /// Get nodes
        /// </summary>
        /// <param name="entity">TIA root entoty</param>
        /// <returns>List of nodes</returns>
        internal virtual IList<INode> GetNodes(TiaSelectionToolEntity entity)
            => GetNodes(entity?.Business?.Graph?.Nodes);

        /// <summary>
        /// Get nodes
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        /// <returns>List of nodes</returns>
        internal virtual IList<INode> GetNodes(IEnumerable<NodeEntity> nodes)
            => nodes is null ? new List<INode>() : _mapper.Map<IList<INode>>(nodes);

        #endregion
    }
}