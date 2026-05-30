using TaskApp.DTOs;

namespace TaskApp.Services.IServices
{
    public interface IAuthService
    {
        UserResponseDTO Register(RegisterDTO registerDTO);
        bool CheckEmailExists(string email);
        LoginResponseDTO Login(LoginRequestDTO loginRequestDTO);
    }
}
