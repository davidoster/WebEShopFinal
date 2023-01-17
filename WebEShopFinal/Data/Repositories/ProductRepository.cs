using Microsoft.EntityFrameworkCore;
using WebEShopFinal.Models;

namespace WebEShopFinal.Data.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            return _db.Products.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> AddOrUpdate(Product entity)
        {
            _db.Products.Update(entity);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            int result = 0;
            var Product = _db.Products.Where(c => c.Id == id).FirstOrDefault();
            if (Product != null)
            {
                _db.Products.Remove(Product);
                result = await _db.SaveChangesAsync();
            }
            return result;
        }
    }
}
