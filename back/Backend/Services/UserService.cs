using Backend.Repositories;
using Backend.Models;
using Backend.DTO;
namespace Backend.Services
{
    public class UserService
    {
        private readonly UserRepository _repo;
        private readonly JwtService _jwtService;
        public UserService(UserRepository repo,JwtService jwt)
        {
            _repo = repo;
            _jwtService = jwt;
        }
        public async Task<User?> addUser(CreateUserDto dto)
        {

            var existinguser=await _repo.GetUserByUserNameAsync(dto.UserName);
            if (existinguser != null) return null;

            var user = new User
            {
                UserName = dto.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            };
            return await _repo.CreateAsync(user);
        }
        public async Task<string?> login(LoginUserDto dto)
        {
            var user=await _repo.GetUserByUserNameAsync(dto.UserName);

            if (user == null) return null;

            bool valid=BCrypt.Net.BCrypt.Verify(dto.Password,user.Password);

            if (valid) return _jwtService.GenerateToken(user);

            return null;
        }
    }
}
