using Backend.DTO;
using Backend.Models;
using Backend.Services;
using MongoDB.Bson;
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
        public async Task<(List<Ad> items, long total)> SearchAsync(
            string? query, string? location, int? minPrice, int? maxPrice, int page, int pageSize)
        {
            var builder = Builders<Ad>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrWhiteSpace(query))
                filter &= builder.Regex(a => a.Title, new BsonRegularExpression(query, "i"));

            if (!string.IsNullOrWhiteSpace(location))
                filter &= builder.Regex(a => a.Location, new BsonRegularExpression(location, "i"));

            if (minPrice.HasValue)
                filter &= builder.Gte(a => a.Price, minPrice.Value);

            if (maxPrice.HasValue)
                filter &= builder.Lte(a => a.Price, maxPrice.Value);

            var total = await _database.Ads.CountDocumentsAsync(filter);
            var items = await _database.Ads.Find(filter)
                .SortByDescending(a => a.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return (items, total);
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
