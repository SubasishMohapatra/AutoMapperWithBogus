namespace AutoMapperWithBogus
{
    public class TruckModel : IVehicle
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; } = default!;
        public string Fuel { get; set; } = default!;
        public int PayloadCapacity { get; set; }
    }
}