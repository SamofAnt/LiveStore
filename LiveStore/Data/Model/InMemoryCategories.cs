using LiveStore.Data.Interfaces;
using LiveStore.ORM;
using LiveStore.ORM.Repositories;

namespace LiveStore.Data.Model;

public class InMemoryCategories : ICategories
{
    private readonly ICategoryRepository _categories;

    public InMemoryCategories(StoreContext context)
    {
        _categories = new CategoryRepository(context);
    }

    public IReadOnlyCollection<Category> GetCategories()
    {
        return _categories.GetAll().Result.ToList();
    }

    public Task<Category> GetCategoryById(int id)
    {
        return _categories.GetById(id);
    }
}