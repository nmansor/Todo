using System;
using System.Collections.Generic;
using System.Text;
using Todo.Infrastructure.Persistence.Entities;

namespace Todo.Infrastructure.Persistence.Entities
{
    public class TodoList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TodoItem> TodoItems { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
