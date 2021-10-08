using System;
using System.Collections.Generic;
using System.IO;
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

        internal FileRepository(string filePath, IDeserializer deserializer, IMapper mapper)
        {
            _filePath = string.IsNullOrWhiteSpace(filePath) ? throw new ArgumentNullException(nameof(filePath)) : filePath;
            _deserializer = deserializer ?? throw new ArgumentNullException(nameof(deserializer));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion


        #region Methods

        public Task<IList<INode>> GetNodesAsync()
            => Task.Run(GetNodes);

        internal virtual IList<INode> GetNodes()
            => GetNodes(_deserializer.Deserialize(_filePath));

        internal virtual IList<INode> GetNodes(TiaSelectionToolEntity entity)
            => GetNodes(entity?.Business?.Graph?.Nodes);

        internal virtual IList<INode> GetNodes(IEnumerable<NodeEntity> nodes)
            => nodes is null ? new List<INode>() : _mapper.Map<IList<INode>>(nodes);

        #endregion
    }
}