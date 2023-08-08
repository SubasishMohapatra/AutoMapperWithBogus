using Bogus.DataSets;
using System.Text.Json;

namespace AutoMapperWithBogus
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string AboutMe { get; set; } = default!;
        public int YearsOld { get; set; }
        public List<VehicleModel> Vehicles { get; set; } = default!;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}