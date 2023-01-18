using AutoMapper;
using Gitgruppen.Models;
using GitGruppen.Core;

namespace Gitgruppen.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Member, MemberView>()
                .ForMember(
                dest => dest.MemberHasNrVehicles,
                from => from.MapFrom(m => m.Vehicles.Count));
        }
    }
}
