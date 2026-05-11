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
            var imageUrl = await SaveImageAsync(dto.Image);
            var ad = new Ad
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                SellerId = dto.SellerId,
                Image=imageUrl,
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


        private async Task<string> SaveImageAsync(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);//vadim ekstenziju
            var uniqueName = $"{Guid.NewGuid()}{extension}"; //generisanje random imena unique

            var uploadsFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "uploads");
            Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, uniqueName);

            using var stream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(stream);

            return $"https://localhost:7123/uploads/{uniqueName}";
        }
    }
}
