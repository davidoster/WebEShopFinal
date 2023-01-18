namespace WebEShopFinal.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<int> AddOrUpdate(T entity);
        Task<int> DeleteAsync(int id);
    }
}
