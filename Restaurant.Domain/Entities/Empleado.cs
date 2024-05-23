
using Restaurant.Domain.Core;

namespace Restaurant.Domain.Entities
{
    public  class Empleado: Person
    {
        public string? Cargo { get; set; }
    }
}
