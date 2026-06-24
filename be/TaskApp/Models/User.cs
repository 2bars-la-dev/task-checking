using System.ComponentModel.DataAnnotations;

namespace TaskApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<TodoTask> Tasks { get; set; } = new List<TodoTask>();
    }
}