using Microsoft.EntityFrameworkCore;
using TaskApp.Models;

namespace TaskApp.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoTask>().HasData(
                new TodoTask
                {
                    Id = 1,
                    Name = "Learn ASP.NET Core",
                    Description = "Study controllers, routing, middleware",
                    Status = TodoTaskStatus.InProgress,
                    Deadline = new DateTime(2026, 3, 21),
                    UpdatedAt = new DateTime(2026, 3, 18)
                },
                new TodoTask
                {
                    Id = 2,
                    Name = "Practice EF Core",
                    Description = "Work with DbContext and migrations",
                    Status = TodoTaskStatus.Pending,
                    Deadline = new DateTime(2026, 3, 23),
                    UpdatedAt = new DateTime(2026, 3, 18)
                },
                new TodoTask
                {
                    Id = 3,
                    Name = "Build Task API",
                    Description = "Create CRUD endpoints",
                    Status = TodoTaskStatus.Pending,
                    Deadline = new DateTime(2026, 3, 25),
                    UpdatedAt = new DateTime(2026, 3, 18)
                },
                new TodoTask
                {
                    Id = 4,
                    Name = "Fix bugs",
                    Description = "Resolve API errors",
                    Status = TodoTaskStatus.InProgress,
                    Deadline = new DateTime(2026, 3, 20),
                    UpdatedAt = new DateTime(2026, 3, 18)
                },
                new TodoTask
                {
                    Id = 5,
                    Name = "Write docs",
                    Description = "Document API endpoints",
                    Status = TodoTaskStatus.Completed,
                    Deadline = new DateTime(2026, 3, 15),
                    UpdatedAt = new DateTime(2026, 3, 18)
                }
            );
        }
    }
}
