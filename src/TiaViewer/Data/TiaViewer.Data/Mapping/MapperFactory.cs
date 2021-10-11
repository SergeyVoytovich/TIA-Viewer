using AutoMapper;

namespace TiaViewer.Data.Mapping
{
    /// <summary>
    /// Mapper factory
    /// </summary>
    internal static class MapperFactory
    {
        /// <summary>
        /// Initialize new mapper
        /// </summary>
        /// <returns>Mapper</returns>
        public static IMapper Init()
        {
            var configuration = new MapperConfiguration(cnf =>
            {
                cnf.AddProfile<EntitiesProfile>();
            });

            configuration.AssertConfigurationIsValid();

            return configuration.CreateMapper();
        }
    }
}
