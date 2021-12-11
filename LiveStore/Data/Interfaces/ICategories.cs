namespace LiveStore.Data.Interfaces;

public interface ICategories
{
    IReadOnlyCollection<Category> GetCategories();
    Category? GetCategoryById(int id);
}