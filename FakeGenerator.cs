using Bogus;

namespace AutoMapperWithBogus
{
    internal class FakeGenerator
    {
        private static Faker<VehicleEntity> GetVehicleGenerator(Guid employeeId)
        {
            return new Faker<VehicleEntity>()
                .RuleFor(v => v.Id, _ => Guid.NewGuid())
                .RuleFor(v => v.EmployeeId, _ => employeeId)
                .RuleFor(v => v.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(v => v.Fuel, f => f.Vehicle.Fuel());
        }

        private static Faker<EmployeeEntity> GetEmployeeGenerator()
        {
            return new Faker<EmployeeEntity>()
                .RuleFor(e => e.Id, _ => Guid.NewGuid())
                .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                .RuleFor(e => e.LastName, f => f.Name.LastName())
                .RuleFor(e => e.Address, f => f.Address.FullAddress())
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
                .RuleFor(e => e.AboutMe, f => f.Lorem.Paragraph(1))
                .RuleFor(e => e.YearsOld, f => f.Random.Int(18, 90));
                //.RuleFor(e => e.Vehicles, (_, e) =>
                //{
                //    return GetBogusVehicleData(e.Id);
                //});
        }

        public static List<VehicleEntity> GetBogusVehicleData(Guid employeeId)
        {
            var vehicleGenerator = GetVehicleGenerator(employeeId);
            var generatedVehicles = vehicleGenerator.Generate(2);
            //Vehicles.AddRange(generatedVehicles);
            return generatedVehicles;
        }

        public static List<EmployeeEntity> GetBogusEmployeeData()
        {
            var employeeGenerator = GetEmployeeGenerator();
            var generatedEmployees = employeeGenerator.Generate(2);
            //Employees.AddRange(generatedEmployees);
            return generatedEmployees;
        }
    }
}
