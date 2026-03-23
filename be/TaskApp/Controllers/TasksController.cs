using AutoMapper;
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
            //Get the list from database
            List<TodoTask> tasks = _context.TodoTasks.ToList();

            //Map to dto
            var result = _mapper.Map<List<TaskResponseDTO>>(tasks);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            //Find the task
            TodoTask? task = _context.TodoTasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            TaskResponseDTO taskResponseDTO = _mapper.Map<TaskResponseDTO>(task);
            return Ok(taskResponseDTO);
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] CreateTaskDTO taskDto)
        {
            // Map DTO (client data) to Entity model
            TodoTask task = _mapper.Map<TodoTask>(taskDto);

            // Add new task to DbContext (not saved to DB yet)
            _context.TodoTasks.Add(task);

            // Persist changes to the database
            _context.SaveChanges();

            // Map saved entity back to response DTO
            var result = _mapper.Map<TaskResponseDTO>(task);

            // Return 201 Created with location header to GET endpoint
            return CreatedAtAction(
                nameof(GetTask),           // Target action to retrieve created resource
                new { id = task.Id },      // Route values (new resource ID)
                result                     // Response body
            );
        }

        [HttpPut("{id}")]
        public IActionResult EditTask(int id, [FromBody] UpdateTaskDTO dto)
        {
            // Find existing task by id
            var todoTask = _context.TodoTasks.FirstOrDefault(t => t.Id == id);

            // Return 404 if not found
            if (todoTask == null) return NotFound();

            // Map updated fields from DTO to existing entity
            _mapper.Map(dto, todoTask);

            // Update modified timestamp
            todoTask.UpdatedAt = DateTime.UtcNow;

            // Save changes to database
            _context.SaveChanges();

            // Return 204 No Content (successful update, no body)
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTask(int id)
        {
            // Find task by id
            var task = _context.TodoTasks.FirstOrDefault(task => task.Id == id);

            // Return 404 if task does not exist
            if (task == null) return NotFound();

            // Remove task from DbContext
            _context.TodoTasks.Remove(task);

            // Persist deletion to database
            _context.SaveChanges();

            // Return 204 No Content (successful deletion)
            return NoContent();
        }
    }
}
