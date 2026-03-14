using System.ComponentModel.DataAnnotations;

namespace TaskApp.Models
{
    public class TodoTask
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        public TodoTaskStatus Status { get; set; } = TodoTaskStatus.Pending;

        public DateTime Deadline { get; set; }

        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public enum TodoTaskStatus
    {
        Pending,
        InProgress,
        Completed
    }
}