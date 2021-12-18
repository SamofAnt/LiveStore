using LiveStore.Data.Interfaces;
using LiveStore.ORM;
using LiveStore.ORM.Repositories;

namespace LiveStore.Data.Model;

public class InMemoryCatalog : ICatalog
{
    private readonly IClock _currentDate;
    private readonly IProductRepository _products;

    public InMemoryCatalog(IClock currentDate, StoreContext context)
    {
        _currentDate = currentDate;
        _products = new ProductRepository(context);
    }

    public IReadOnlyCollection<Product> GetProducts()
    {
        var date = _currentDate.GetCurrentDate();
        if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            return _products.GetAll().Result
                .Select(it => new Product(it.CategoryId, it.Name, it.Price * 1.5m, it.Image, it.Description))
                .ToList();
        return _products.GetAll().Result.ToList();
    }
}