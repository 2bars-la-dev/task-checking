using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskApp.DTOs;
using TaskApp.Services.IServices;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        //#region Unauthorization
        //[HttpGet]
        //public IActionResult GetAllTasks()
        //{
        //    // Call service to get all tasks
        //    var result = _taskService.GetAll();

        //    // Return 200 OK with list
        //    return Ok(result);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetTask(int id)
        //{
        //    // Call service to find task by id
        //    var task = _taskService.GetById(id);

        //    // Return 404 if not found
        //    if (task == null) return NotFound();

        //    // Return 200 OK with task data
        //    return Ok(task);
        //}

        //[HttpPost]
        //public IActionResult AddTask([FromBody] CreateTaskDTO dto)
        //{
        //    // Call service to create new task
        //    var result = _taskService.Create(dto);

        //    // Return 201 Created with location header
        //    return CreatedAtAction(
        //        nameof(GetTask),        // Endpoint to get created task
        //        new { id = result.Id }, // Route value
        //        result                 // Response body
        //    );
        //}

        //[HttpPut("{id}")]
        //public IActionResult EditTask(int id, [FromBody] UpdateTaskDTO dto)
        //{
        //    // Call service to update task
        //    var isUpdated = _taskService.Update(id, dto);

        //    // Return 404 if task not found
        //    if (!isUpdated) return NotFound();

        //    // Return 204 No Content (success, no body)
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult RemoveTask(int id)
        //{
        //    // Call service to delete task
        //    var isDeleted = _taskService.Delete(id);

        //    // Return 404 if task not found
        //    if (!isDeleted) return NotFound();

        //    // Return 204 No Content (success)
        //    return NoContent();
        //}
        //#endregion

        #region Authorized

        private int GetCurrentUserId()
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userIdStr!);
        }

        [HttpGet("my-tasks")]
        public IActionResult GetMyTasks()
        {
            var tasks = _taskService.GetTasksByUser(GetCurrentUserId());
            return Ok(tasks);
        }

        [HttpGet("my-tasks/{id}")]
        public IActionResult GetMyTask(int id)
        {
            var task = _taskService.GetByIdForUser(id, GetCurrentUserId());
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost("my-tasks")]
        public IActionResult AddMyTask([FromBody] CreateTaskDTO dto)
        {
            var result = _taskService.CreateForUser(dto, GetCurrentUserId());
            return CreatedAtAction(nameof(GetMyTask), new { id = result.Id }, result);
        }

        [HttpPut("my-tasks/{id}")]
        public IActionResult EditMyTask(int id, [FromBody] UpdateTaskDTO dto)
        {
            var isUpdated = _taskService.UpdateForUser(id, dto, GetCurrentUserId());
            if (!isUpdated) return NotFound();
            return NoContent();
        }

        [HttpDelete("my-tasks/{id}")]
        public IActionResult RemoveMyTask(int id)
        {
            var isDeleted = _taskService.DeleteForUser(id, GetCurrentUserId());
            if (!isDeleted) return NotFound();
            return NoContent();
        }

        #endregion
    }
}