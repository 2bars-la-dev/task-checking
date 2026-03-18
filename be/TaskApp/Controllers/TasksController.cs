using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApp.DataContext;
using TaskApp.DTOs;
using TaskApp.Models;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly ApplicationDbContext _context;

        public TasksController(IMapper mapper, ApplicationDbContext context) 
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            
            List<TodoTask> tasks = _context.TodoTasks.ToList();

            var result = _mapper.Map<List<TaskResponseDTO>>(tasks);

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
