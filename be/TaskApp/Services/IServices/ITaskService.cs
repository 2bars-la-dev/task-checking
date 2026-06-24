using TaskApp.DTOs;

namespace TaskApp.Services.IServices
{
    public interface ITaskService
    {
        List<TaskResponseDTO> GetAll();

        TaskResponseDTO? GetById(int id);

        TaskResponseDTO Create(CreateTaskDTO dto);

        bool Update(int id, UpdateTaskDTO dto);

        bool Delete(int id);
        List<TaskResponseDTO> GetTasksByUser(int userId);
        public TaskResponseDTO? GetByIdForUser(int taskId, int userId);
        public TaskResponseDTO CreateForUser(CreateTaskDTO dto, int userId);
        public bool UpdateForUser(int taskId, UpdateTaskDTO dto, int userId);
        public bool DeleteForUser(int taskId, int userId);

    }
}
