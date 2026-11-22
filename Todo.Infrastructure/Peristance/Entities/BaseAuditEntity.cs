using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Infrastructure.Peristance.Entities
{
    internal class BaseAuditEntity: BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime  UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
