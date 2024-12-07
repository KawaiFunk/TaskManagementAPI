using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;
using Task = TaskManagementAPI.Models.Task;

namespace TaskManagementAPI.Data
{
    public class TasksContext : DbContext
    {
        public TasksContext(DbContextOptions<TasksContext> options) : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
