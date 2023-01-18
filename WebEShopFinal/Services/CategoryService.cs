using WebEShopFinal.Data.Repositories;
using WebEShopFinal.Models;

namespace WebEShopFinal.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        public CategoryService(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<Category?> AddOrUpdateCategory(Category category)
        {
            return await _repository.GetByIdAsync(await _repository.AddOrUpdate(category));
        }

        public async Task<ICollection<Category>> GetCategories()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> RemoveCategory(int id)
        {
            return Convert.ToBoolean(await _repository.DeleteAsync(id));
        }
    }
}
