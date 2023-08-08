using AutoMapper;

namespace AutoMapperWithBogus
{
    class Program
    {
        public static void Main(string[] args)
        {
            var employees = FakeGenerator.GenerateFakeEmployees(5);
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
                Vehicles = new List<IVehicle>
            {
                new CarEntity
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = "Toyota",
                    Fuel = "Gasoline",
                    NumberOfDoors=4
                },
                 new TruckEntity
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = "Toyota",
                    Fuel = "Gasoline",
                    PayloadCapacity=30
                }
            }
            };

            //EmployeeModel employeeModel = mapper.Map<EmployeeModel>(employeeEntity);

            var employeesModel = mapper.Map<List<EmployeeModel>>(employees);

            Console.ReadLine();
        }
    }
}