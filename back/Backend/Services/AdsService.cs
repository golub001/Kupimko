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

            try
            {
                var ad = new Ad
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    Price = dto.Price,
                    CategoryId = dto.CategoryId,
                    SellerId = dto.SellerId,
                    Image = imageUrl,
                    Location = dto.Location
                };
                return await _repo.CreateAdAsync(ad);
            }
            catch (Exception ex)
            {
                DeleteImage(imageUrl);
                throw;
            }
        }
        public async Task<PagedResult<Ad>> SearchAsync(
            string? query, string? location, int? minPrice, int? maxPrice, int page, int pageSize)
        {
            var (items, total) = await _repo.SearchAsync(query, location, minPrice, maxPrice, page, pageSize);
            return new PagedResult<Ad>
            {
                Items = items,
                Total = (int)total,
                Page = page,
                TotalPages = (int)Math.Ceiling((double)total / pageSize)
            };
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

            return $"http://localhost:5026/uploads/{uniqueName}";
        }
        private void DeleteImage(string imageUrl)
        {
            var filename=Path.GetFileName(imageUrl);

            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot", "uploads",
                filename
            );

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            
        }
    }
}
