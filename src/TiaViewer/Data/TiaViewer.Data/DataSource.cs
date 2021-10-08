﻿using TiaViewer.Common.Data;
using TiaViewer.Data.Mapping;
using TiaViewer.Data.Utils;

namespace TiaViewer.Data.Repositories
{
    public class DataSource : IDataSource
    {
        public IRepository GetRepository(string filePath)
            => new FileRepository(filePath, new Deserializer(), MapperFactory.Init());
    }
}
