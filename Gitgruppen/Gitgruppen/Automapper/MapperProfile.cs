using AutoMapper;
using Gitgruppen.Models;
using GitGruppen.Core;

namespace Gitgruppen.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Vehicle, VehicleView>();
            CreateMap<Vehicle, OverViewModel>();
            CreateMap<Member, MemberDetailsView>();
            CreateMap<Member, MemberView>()
                .ForMember(
                dest => dest.MemberHasNrVehicles,
                from => from.MapFrom(m => m.Vehicles.Count));
        }
    }
}
