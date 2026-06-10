using TaskApp.Models;

namespace TaskApp.Services.IServices
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
