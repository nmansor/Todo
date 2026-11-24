using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Todo.Infrastructure.Persistence.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public TodoList ToDoList { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public DateTime? DoDate { get; set; }
        public DateTime? RemiderDate { get; set; }
        public DateTime? CompleteAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<TodoItemTag> TodoItemTag { get; set; }  //navigation property
        public ICollection<Comment> Comments { get; set; }
    }
}
