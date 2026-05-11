using Backend.Models;
using Backend.Services;
using MongoDB.Driver;

namespace Backend.Repositories
{
    public class UserRepository
    {
        private readonly MongoDbContext _database;

        public UserRepository(MongoDbContext database)
        {
            _database = database;
        }
        public async Task<User> CreateAsync(User user)
        {
           await _database.Users.InsertOneAsync(user);
            return user;
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await _database.Users.Find(u=>u.UserName == username).FirstOrDefaultAsync();
        }
    }
}
