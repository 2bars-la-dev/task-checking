using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApp.DTOs;
using TaskApp.Models;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        public readonly IMapper _mapper;

        public TasksController(IMapper mapper) 
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = new List<TodoTask>
            {
                new TodoTask
                {
                    Id = 1,
                    Name = "Learn ASP.NET Core",
                    Description = "Study controllers, routing, and middleware",
                    Status = TodoTaskStatus.InProgress,
                    Deadline = DateTime.Now.AddDays(5)
                },
                new TodoTask
                {
                    Id = 2,
                    Name = "Build Task API",
                    Description = "Implement CRUD endpoints for tasks",
                    Status = TodoTaskStatus.Pending,
                    Deadline = DateTime.Now.AddDays(7)
                },
                new TodoTask
                {
                    Id = 3,
                    Name = "Learn Entity Framework Core",
                    Description = "Understand DbContext, migrations, and LINQ",
                    Status = TodoTaskStatus.Pending,
                    Deadline = DateTime.Now.AddDays(10)
                },
                new TodoTask
                {
                    Id = 4,
                    Name = "Add AutoMapper",
                    Description = "Map DTOs and entities automatically",
                    Status = TodoTaskStatus.Completed,
                    Deadline = DateTime.Now.AddDays(-2)
                },
                new TodoTask
                {
                    Id = 5,
                    Name = "Write API documentation",
                    Description = "Describe endpoints and request/response models",
                    Status = TodoTaskStatus.Pending,
                    Deadline = DateTime.Now.AddDays(3)
                }
            };

            var result = _mapper.Map<List<TaskResonseDTO>>(tasks);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            return Ok(new { id = 1 });
        }

        [HttpPost]
        public IActionResult AddTask(TodoTask task)
        {
            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult EditTask(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTask(int id) 
        {
            return Ok();
        }

        public static TodoTaskStatus ParseStatus(string status)
        {
            return status switch
            {
                "Pending" => TodoTaskStatus.Pending,
                "In progress" => TodoTaskStatus.InProgress,
                "Completed" => TodoTaskStatus.Completed,
                _ => throw new ArgumentException("Invalid status")
            };
        }
    }
}
