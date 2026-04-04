using AutoMapper;
using TaskApp.DTOs;
using TaskApp.Models;

namespace TaskApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateTaskDTO, TodoTask>();
            CreateMap<UpdateTaskDTO, TodoTask>();
            CreateMap<TodoTask, TaskResponseDTO>();

            CreateMap<User, UserResponseDTO>();
        }
    }
}
