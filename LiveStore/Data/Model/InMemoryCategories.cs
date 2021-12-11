using LiveStore.Data.Interfaces;

namespace LiveStore.Data.Model;

public class InMemoryCategories : ICategories
{
    private readonly IReadOnlyCollection<Category> _categories = new Category[]
    {
        new(1, "Смартфоны и гаджеты"),
        new(2, "Телевизоры"),
        new(3, "Техника для кухни"),
        new(4, "Игры и софт")
    };

    public IReadOnlyCollection<Category> GetCategories()
    {
        return _categories;
    }

    public Category? GetCategoryById(int id)
    {
        return _categories.SingleOrDefault(c => c.Id == id);
    }
}