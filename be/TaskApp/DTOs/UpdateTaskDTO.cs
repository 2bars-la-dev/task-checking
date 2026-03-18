using System.ComponentModel.DataAnnotations;
using TaskApp.Models;

namespace TaskApp.DTOs
{
    public class UpdateTaskDTO
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        public TodoTaskStatus Status { get; set; } 
        public DateTime Deadline { get; set; }
    }
}
