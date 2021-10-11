using System.Linq;
using AutoMapper;
using TiaViewer.Common.Domain;
using TiaViewer.Data.Entities;

namespace TiaViewer.Data.Mapping
{
    /// <summary>
    /// Entities mapping provider
    /// </summary>
    internal class EntitiesProfile : Profile
    {
        /// <summary>
        /// Initialized new instance
        /// </summary>
        public EntitiesProfile()
        {
            CreateMap<NodeEntity, INode>()
                .ConstructUsing(n => new Node())
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dst => dst.Properties, opt => opt.MapFrom(src => src.Properties.ToDictionary(k => k.Key, v => v.Value)))
                ;
        }
    }
}
