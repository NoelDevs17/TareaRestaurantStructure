using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Core
{
    public abstract class  AuditableEntity
    {
        public DateTime? CreationDate { get; set; }
    }
}
