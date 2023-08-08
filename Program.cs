using AutoMapper;

namespace AutoMapperWithBogus
{
    class Program
    {
        public static void Main(string[] args)
        {
            var employees = FakeGenerator.GetBogusEmployeeData();
            foreach (var employee in employees)
            {
                var vehicles = FakeGenerator.GetBogusVehicleData(employee.Id);
                employee.Vehicles = vehicles;
            }

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();

            var employeeId = Guid.NewGuid();
            var employeeEntity = new EmployeeEntity
            {
                Id = employeeId,
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                Email = "john@example.com",
                AboutMe = "Software Developer",
                YearsOld = 30,
                Vehicles = new List<VehicleEntity>
            {
                new VehicleEntity
                {
                    EmployeeId=employeeId,
                    Id = Guid.NewGuid(),
                    Manufacturer = "Toyota",
                    Fuel = "Gasoline"
                }
            }
            };

            EmployeeModel employeeModel = mapper.Map<EmployeeModel>(employeeEntity);

            var employeesModel= mapper.Map<List<EmployeeModel>>(employees);

            Console.ReadLine();
        }
    }
}