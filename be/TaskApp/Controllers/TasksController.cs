using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = new[]
            {
                new { id = 1, title = "Task 1" }
            };

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            return Ok(new { id = 1 });
        }

        [HttpPost]
        public IActionResult AddTask(Task task)
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
    }
}
