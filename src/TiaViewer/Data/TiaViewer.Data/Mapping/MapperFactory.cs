using AutoMapper;

namespace TiaViewer.Data.Mapping
{
    internal static class MapperFactory
    {
        public static IMapper Init()
        {
            var configuration = new MapperConfiguration(cnf =>
            {
                cnf.AddProfile<TiaProfile>();
            });

            configuration.AssertConfigurationIsValid();

            return configuration.CreateMapper();
        }
    }
}
