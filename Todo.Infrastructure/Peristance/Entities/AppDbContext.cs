using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Todo.Infrastructure.Peristance.Entities
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        DbSet<User> Users { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<ToDoItemTag> ToDoItemTags { get; set; }
        DbSet<ToDoItem> ToDoItems { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<ActivityLog> ActivityLogs { get; set; }


    }
}
