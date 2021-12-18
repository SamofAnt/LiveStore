namespace LiveStore.ORM.Repositories;

public interface ICategoryRepository
{
    Task<Category> GetById(int id);
    Task<IEnumerable<Category>> GetAll();
    Task<Category?> FindById(int id);
    bool TryGet(int id, out Category? entity);
    Task Add(Category entity);
    Task Update(Category entity);
    Task<bool> Remove(int id);
}