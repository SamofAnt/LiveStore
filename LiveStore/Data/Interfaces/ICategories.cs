namespace LiveStore.Data.Interfaces;

public interface ICategories
{
    IReadOnlyCollection<Category> GetCategories();
    Task<Category> GetCategoryById(int id);
}