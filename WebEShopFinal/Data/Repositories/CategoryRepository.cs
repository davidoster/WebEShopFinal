using Microsoft.EntityFrameworkCore;
using WebEShopFinal.Models;

namespace WebEShopFinal.Data.Repositories
{
    public class CategoryRepository : IGenericRepository<Category>
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public Task<Category?> GetByIdAsync(int id)
        {
            return _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> AddOrUpdate(Category entity)
        {
            _db.Categories.Update(entity);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                return -1;
            }
            return entity.Id;
        }

        // PLEASEEEEE chnage this so it doesn't implement any Business Logic (BL)
        public async Task<int> DeleteAsync(int id)
        {
            int result = 0;
            var category = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category != null)
            {
                _db.Categories.Remove(category);
                result = await _db.SaveChangesAsync();
            }
            return result;
        }
    }
}
