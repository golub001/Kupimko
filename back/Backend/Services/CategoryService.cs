using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _repo;
        public CategoryService(CategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Category>> GetAll()=> await _repo.GetAllCategories();
    }
}
