using TaskApp.DTOs;

namespace TaskApp.Services
{
    public interface ITaskService
    {
        List<TaskResponseDTO> GetAll();

        TaskResponseDTO? GetById(int id);

        TaskResponseDTO Create(CreateTaskDTO dto);

        bool Update(int id, UpdateTaskDTO dto);

        bool Delete(int id);
    }
}
