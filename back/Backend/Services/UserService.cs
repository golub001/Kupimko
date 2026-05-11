using Backend.Repositories;
using Backend.Models;
using Backend.DTO;
namespace Backend.Services
{
    public class UserService
    {
        private UserRepository _repo;

        public UserService(UserRepository repo)
        {
            _repo = repo;
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
        public async Task<User> login(LoginUserDto dto)
        {
            var user=await _repo.GetUserByUserNameAsync(dto.UserName);

            if (user == null) return null;

            bool valid=BCrypt.Net.BCrypt.Verify(dto.Password,user.Password);

            if (valid) return user;

            return null;
        }
    }
}
