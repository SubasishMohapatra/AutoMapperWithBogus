using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoMapperWithBogus
{
    public class VehicleEntity
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Manufacturer { get; set; } = default!;
        public string Fuel { get; set; } = default!;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
