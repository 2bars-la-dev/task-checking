using System.ComponentModel.DataAnnotations;
using TaskApp.Models;

namespace TaskApp.DTOs
{
    public class UpdateTaskDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Name max 200 characters")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Description max 1000 characters")]
        public string? Description { get; set; }
        public TodoTaskStatus Status { get; set; }
        public DateTime Deadline { get; set; }
    }
}
