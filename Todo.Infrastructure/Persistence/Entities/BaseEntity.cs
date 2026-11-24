using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Infrastructure.Persistence.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
    }
}
