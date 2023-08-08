using AutoMapper;

namespace AutoMapperWithBogus
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleBaseEntity, IVehicle>().Include<CarEntity, CarModel>().Include<TruckEntity, TruckModel>();

            CreateMap<CarEntity, CarModel>()
                .ForMember(dest => dest.NumberOfDoors, opt => opt.MapFrom(src => src.NumberOfDoors));

            CreateMap<TruckEntity, TruckModel>()
                .ForMember(dest => dest.PayloadCapacity, opt => opt.MapFrom(src => src.PayloadCapacity));

            CreateMap<VehicleBaseEntity, IVehicle>();
            CreateMap<EmployeeEntity, EmployeeModel>()
                .ForMember(dest => dest.Vehicles, opt => opt.MapFrom(src => src.Vehicles));
        }
    }
}
