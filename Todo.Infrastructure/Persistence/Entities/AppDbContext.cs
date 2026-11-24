using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Todo.Infrastructure.Persistence.Entities
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        DbSet<User> Users { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<TodoItemTag> ToDoItemTags { get; set; }
        DbSet<TodoItem> ToDoItems { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<ActivityLog> ActivityLogs { get; set; }

 

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(c => c.User)
                      .WithMany()
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.TodoItem)
                      .WithOne()
                      .HasForeignKey<Comment>(c => c.TodoItemId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Example: if TodoItem also has a User foreign key cascading from User,
            // break that cascade chain so it doesn't collide with Comment:
            modelBuilder.Entity<TodoItem>()
                .HasOne<User>() // or .HasOne(t => t.User).WithMany()
                .WithMany()
                .HasForeignKey("UserId") // adjust property name if different
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

