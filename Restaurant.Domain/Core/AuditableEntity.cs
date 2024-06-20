

namespace Restaurant.Domain.Core
{
    public abstract class  AuditableEntity
    {
        public DateTime? CreationDate { get; set; }
    }
}
