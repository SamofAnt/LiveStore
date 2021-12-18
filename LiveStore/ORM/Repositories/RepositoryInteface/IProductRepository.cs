using LiveStore.Data.Model;

namespace LiveStore.ORM.Repositories;

public interface IProductRepository
{
    Task<Product> GetById(int id);
    Task<IEnumerable<Product>> GetAllByCategoryId(int id);
    Task<IEnumerable<Product>> GetAll();
    Task<Product?> FindById(int id);
    bool TryGet(int id, out Product? entity);
    Task Add(Product entity);
    Task Update(Product entity);
    Task<bool> Remove(int id);
}