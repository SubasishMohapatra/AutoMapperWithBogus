namespace AutoMapperWithBogus
{
    public abstract class VehicleBaseEntity : IVehicle
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; } = default!;
        public string Fuel { get; set; } = default!;
    }

}
