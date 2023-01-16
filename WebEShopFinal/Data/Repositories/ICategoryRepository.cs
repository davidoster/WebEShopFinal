using WebEShopFinal.Models;

namespace WebEShopFinal.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> Get(int? id);
        Task<Category> Get(int id);
        Task<IEnumerable<Category>> GetAll();
        Task<Category> Add(Category category);
        Task<bool> Remove(int id);
    }
}