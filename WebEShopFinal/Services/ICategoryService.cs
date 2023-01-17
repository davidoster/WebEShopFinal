using WebEShopFinal.Models;

namespace WebEShopFinal.Services
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetCategories();
        Task<Category?> GetCategory(int id);
        Task<Category> AddOrUpdateCategory(Category category);
        Task<bool> RemoveCategory(int id);
    }
}
