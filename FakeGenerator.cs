using Bogus;

namespace AutoMapperWithBogus
{
    internal class FakeGenerator
    {
        public static List<CarEntity> GenerateFakeCars(int count)
        {
            var faker = new Faker<CarEntity>()
                .RuleFor(c => c.Id, f => f.Random.Guid())
                .RuleFor(c => c.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(c => c.Fuel, f => f.PickRandom("Gasoline", "Diesel", "Electric"))
                .RuleFor(c => c.NumberOfDoors, f => f.Random.Int(2, 5));

            return faker.Generate(count);
        }

        public static List<TruckEntity> GenerateFakeTrucks(int count)
        {
            var faker = new Faker<TruckEntity>()
                .RuleFor(t => t.Id, f => f.Random.Guid())
                .RuleFor(t => t.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(t => t.Fuel, f => f.PickRandom("Gasoline", "Diesel"))
                .RuleFor(t => t.PayloadCapacity, f => f.Random.Int(100, 1000));

            return faker.Generate(count);
        }

        public static List<EmployeeEntity> GenerateFakeEmployees(int count)
        {
            var faker = new Faker<EmployeeEntity>()
                .RuleFor(e => e.Id, f => f.Random.Guid())
                .RuleFor(e => e.FirstName, f => f.Person.FirstName)
                .RuleFor(e => e.LastName, f => f.Person.LastName)
                .RuleFor(e => e.Address, f => f.Address.FullAddress())
                .RuleFor(e => e.Email, f => f.Person.Email)
                .RuleFor(e => e.AboutMe, f => f.Lorem.Sentence())
                .RuleFor(e => e.YearsOld, f => f.Random.Int(18, 60))
                .RuleFor(e => e.Vehicles, (f, e) => GenerateFakeVehicles(f, e)); // Pass both faker and employee

            return faker.Generate(count);
        }

        public static List<IVehicle> GenerateFakeVehicles(Faker faker, EmployeeEntity employee)
        {
            var vehicleEntities = new List<IVehicle>();

            // Generate 1 to 3 vehicles per employee
            int vehicleCount = faker.Random.Int(1, 3);

            for (int i = 0; i < vehicleCount; i++)
            {
                var vehicle = faker.PickRandom<IVehicle>(GenerateFakeCars(1)[0], GenerateFakeTrucks(1)[0]);
                vehicleEntities.Add(vehicle);
            }

            return vehicleEntities;
        }
    }
}
