using LiveStore.Data.Model;

namespace LiveStore.ORM.Repositories;

public interface ICategoryRepository
{
    Task<Category> GetById(int id);
    Task<IEnumerable<Category>> GetAll();
    Task<Category?> FindById(int id);
    Task Add(Category entity);
    Task Update(Category entity);
    Task Remove(Category entity);
}