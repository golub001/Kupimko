using Backend.Models;
using Backend.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Backend.Services
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        
        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database=client.GetDatabase(settings.Value.DatabaseName);
        }
        public IMongoCollection<Category> Categories =>
            _database.GetCollection<Category>("categories");

        

    }
}

