using Microsoft.AspNetCore.Identity;
using TaskApp.DataContext;
using TaskApp.DTOs;
using TaskApp.Models;
using TaskApp.Services.IServices;

namespace TaskApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CheckEmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public UserResponseDTO Register(RegisterDTO registerDTO)
        {
            if (CheckEmailExists(registerDTO.Email))
            {
                return null;
            }

            var user = new User
            {
                Email = registerDTO.Email
            };

            user.PasswordHash = _hasher.HashPassword(user, registerDTO.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return new UserResponseDTO
            {
                Id = user.Id,
                Email = user.Email,
            };
        }

        public LoginResponseDTO Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == loginRequestDTO.Email);

            LoginResponseDTO result = new LoginResponseDTO
            {
                UserId = 0,
                Email = null,
                Message = "Email hoặc mật khẩu không đúng"
            };

            if (user == null)
                return result;

            var hashedResult = _hasher.VerifyHashedPassword(user, user.PasswordHash, loginRequestDTO.Password);

            if (hashedResult == PasswordVerificationResult.Failed)
                return result;

            result.Email = user.Email;
            result.UserId = user.Id;
            result.Message = "Đăng nhập thành công";
            return result;
        }
    }
}
