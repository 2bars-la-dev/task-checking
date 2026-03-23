using AutoMapper;
using TaskApp.DataContext;
using TaskApp.DTOs;
using TaskApp.Models;

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

        public TaskResponseDTO? GetById(int id)
        {
            var task = _context.TodoTasks.FirstOrDefault(t => t.Id == id);

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

        public bool Update(int id, UpdateTaskDTO dto)
        {
            var task = _context.TodoTasks.FirstOrDefault(t => t.Id == id);

            if (task == null) return false;

            _mapper.Map(dto, task);

            task.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var task = _context.TodoTasks.FirstOrDefault(t => t.Id == id);

            if (task == null) return false;

            _context.TodoTasks.Remove(task);
            _context.SaveChanges();

            return true;
        }
    }
}