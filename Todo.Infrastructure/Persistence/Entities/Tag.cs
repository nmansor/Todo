using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Infrastructure.Persistence.Entities
{
    public class Tag
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public string ColorCode { get; set; }
    }
}
