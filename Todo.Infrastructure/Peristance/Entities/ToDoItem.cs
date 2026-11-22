using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Todo.Infrastructure.Peristance.Entities
{
    internal class ToDoItem
    {
        public Guid Id { get; set; }
        public ToDoList ToDoList { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public DateTime? DoDate { get; set; }
        public DateTime? RemiderDate { get; set; }
        public DateTime? CompleteAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ToDoItemTag> ToDoItemTag { get; set; }  //navigation property
        public ICollection<Comment> Comments { get; set; }
    }
}
