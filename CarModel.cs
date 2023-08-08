namespace AutoMapperWithBogus
{
    public class CarModel:IVehicle
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; } = default!;
        public string Fuel { get; set; } = default!;
        public int NumberOfDoors { get; set; }
    }
}