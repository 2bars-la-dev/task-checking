using AutoMapper;
using TaskApp.DataContext;
using TaskApp.DTOs;
using TaskApp.Models;
using TaskApp.Services.IServices;

namespace TaskApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TaskService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<TaskResponseDTO> GetAll()
        {
            var tasks = _context.TodoTasks.ToList();
            return _mapper.Map<List<TaskResponseDTO>>(tasks);
        }

        public TaskResponseDTO? GetById(int taskId)
        {
            var task = _context.TodoTasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) return null;
            return _mapper.Map<TaskResponseDTO>(task);
        }

        public TaskResponseDTO Create(CreateTaskDTO dto)
        {
            var task = _mapper.Map<TodoTask>(dto);
            _context.TodoTasks.Add(task);
            _context.SaveChanges();
            return _mapper.Map<TaskResponseDTO>(task);
        }

        public bool Update(int taskId, UpdateTaskDTO dto)
        {
            var task = _context.TodoTasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) return false;
            _mapper.Map(dto, task);
            task.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int taskId)
        {
            var task = _context.TodoTasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) return false;
            _context.TodoTasks.Remove(task);
            _context.SaveChanges();
            return true;
        }

        public List<TaskResponseDTO> GetTasksByUser(int userId)
        {
            var tasks = _context.TodoTasks
                .Where(t => t.UserId == userId).ToList();
            return _mapper.Map<List<TaskResponseDTO>>(tasks);
        }

        public TaskResponseDTO? GetByIdForUser(int taskId, int userId)
        {
            var task = _context.TodoTasks
                .FirstOrDefault(t => t.Id == taskId && t.UserId == userId);
            if (task == null) return null;
            return _mapper.Map<TaskResponseDTO>(task);
        }

        public TaskResponseDTO CreateForUser(CreateTaskDTO dto, int userId)
        {
            var task = _mapper.Map<TodoTask>(dto);
            task.UserId = userId;
            _context.TodoTasks.Add(task);
            _context.SaveChanges();
            return _mapper.Map<TaskResponseDTO>(task);
        }

        public bool UpdateForUser(int taskId, UpdateTaskDTO dto, int userId)
        {
            var task = _context.TodoTasks
                .FirstOrDefault(t => t.Id == taskId && t.UserId == userId);
            if (task == null) return false;
            _mapper.Map(dto, task);
            task.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteForUser(int taskId, int userId)
        {
            var task = _context.TodoTasks
                .FirstOrDefault(t => t.Id == taskId && t.UserId == userId);
            if (task == null) return false;
            _context.TodoTasks.Remove(task);
            _context.SaveChanges();
            return true;
        }
    }
}