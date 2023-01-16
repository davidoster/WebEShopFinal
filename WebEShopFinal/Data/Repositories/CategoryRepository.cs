using System;
using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebEShopFinal.Models;
using WebEShopFinal.Data;
using Microsoft.EntityFrameworkCore;

namespace WebEShopFinal.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository/*: IGenericRepository<Category>, ICategoryRepository*/
    {
        private ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> Add(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;

        }

        public async Task<Category> Get(int? id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> Get(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            return category;
        }

        public async Task<bool> Remove(int id)
        {
            bool result = false;
            var category = Get(id);
            if (category != null)
            {

                _dbContext.Categories.Remove(await category);
                await _dbContext.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<Category> Update(int id, Category category)
        {
            var dbCategory = _dbContext.Categories.Find(id);
            dbCategory = category;
            _dbContext.Categories.Update(dbCategory);
            await _dbContext.SaveChangesAsync();

            return dbCategory;
        }


    }
}











