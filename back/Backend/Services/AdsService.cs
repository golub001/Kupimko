using Backend.Models;
using Backend.Repositories;
using Backend.DTO;
namespace Backend.Services
{
    public class AdsService
    {
        private readonly AdsRepository _repo;

        public AdsService(AdsRepository repo)
        {
            _repo = repo;
        }

        public async Task<Ad> InsertAdAsync(CreateAdDto dto)
        {
            var ad = new Ad
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                SellerId = dto.SellerId,
                Image = dto.Image,
                Location = dto.Location
            };
            return await _repo.CreateAdAsync(ad);
        }
        public  async Task<List<Ad>> GetAll()
        {
            return await _repo.GetAll();
        }
        public async Task<Boolean> DeleteAsync(string id)
        {
            return await _repo.DeleteAsync(id);
        }
        public async Task<Boolean> UpdateAd(string id, UpdateAdDto dto)
        {
            return await _repo.UpdateAsync(id, dto);
        }
    }
}
