using Backend.DTO;
using Backend.Models;
using Backend.Services;
using MongoDB.Driver;

namespace Backend.Repositories
{
    public class AdsRepository
    {
        private readonly MongoDbContext _database;

        public AdsRepository(MongoDbContext database)
        {
            _database = database;
        }

        public async Task<Ad> CreateAdAsync(Ad ad)
        {
            await _database.Ads.InsertOneAsync(ad);
            return ad;
        }

        public async Task<List<Ad>> GetAll()
        {
            return await _database.Ads.Find(_ =>true).ToListAsync();
        }
        public async Task<Boolean> DeleteAsync(string id)
        {
            var result= await _database.Ads.DeleteOneAsync(u => u.Id == id);
            return result.DeletedCount > 0 ? true : false;
        }
        public async Task<Boolean> UpdateAsync(string id,UpdateAdDto dto)
        {
            var update = Builders<Ad>.Update.Set(ad => ad.Title, dto.Title)
                .Set(ad => ad.Title, dto.Title)
                .Set(ad => ad.Description, dto.Description)
                .Set(ad => ad.Price, dto.Price)
                .Set(ad => ad.Location, dto.Location);

            var result= await _database.Ads.UpdateOneAsync(ad=>ad.Id==id,update);

            return result.ModifiedCount > 0;
        }
    }
}
