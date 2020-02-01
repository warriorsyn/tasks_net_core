using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Models
{
    public class TaskManagementeContext : DbContext
    {

        public TaskManagementeContext(DbContextOptions<TaskManagementeContext> options)
        : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<TodoItem> TodoItem { get; set; }
        public DbSet<Project> Project { get; set; }
    }
}
