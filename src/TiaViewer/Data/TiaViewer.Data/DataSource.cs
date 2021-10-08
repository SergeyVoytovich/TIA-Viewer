using TiaViewer.Common.Data;
using TiaViewer.Data.Mapping;
using TiaViewer.Data.Repositories;
using TiaViewer.Data.Utils;

namespace TiaViewer.Data
{
    public class DataSource : IDataSource
    {
        public IRepository GetRepository(string filePath)
            => new FileRepository(filePath, new Deserializer(), MapperFactory.Init());
    }
}
