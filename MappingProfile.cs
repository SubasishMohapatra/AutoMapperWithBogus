using AutoMapper;

namespace AutoMapperWithBogus
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleEntity, VehicleModel>();
            CreateMap<EmployeeEntity, EmployeeModel>()
                .ForMember(dest => dest.Vehicles, opt => opt.MapFrom(src => src.Vehicles));
        }
    }
}
