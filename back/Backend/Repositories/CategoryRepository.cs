using Backend.Services;
using Backend.Models;
using MongoDB.Driver;

namespace Backend.Repositories
{
    public class CategoryRepository
    {
        private readonly MongoDbContext _database;

        public CategoryRepository(MongoDbContext database)
        {
            _database = database;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await _database.Categories.Find(_ => true).ToListAsync();
        }
    }
}
