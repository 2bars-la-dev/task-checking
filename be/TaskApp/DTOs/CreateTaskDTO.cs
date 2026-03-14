using TaskApp.Models;

namespace TaskApp.DTOs
{
    public class CreateTaskDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TodoTaskStatus Status { get; set; } = TodoTaskStatus.Pending;
        public DateTime Deadline { get; set; }
    }
}
