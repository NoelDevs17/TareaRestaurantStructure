

namespace Restaurant.Domain.Core
{
    public abstract class Person: AuditableEntity
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

    }
}
