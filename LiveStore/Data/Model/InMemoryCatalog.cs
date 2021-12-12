using System.Linq;
using LiveStore.Data.Interfaces;
using LiveStore.ORM;

namespace LiveStore.Data.Model;

public class InMemoryCatalog : ICatalog
{
    private readonly IClock _currentDate;
    private readonly StoreContext _context;
    
    public InMemoryCatalog(IClock currentDate, StoreContext context)
    {
        _currentDate = currentDate;
        _context = context;
    }

    public IReadOnlyCollection<Product> GetProducts()
    {
        var date = _currentDate.GetCurrentDate();
        if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            return _context.Products
                .Select(it => new Product(it.Id, it.CategoryId, it.Name, it.Price * 1.5m, it.Image, it.Description))
                .ToList();
        return _context.Products.ToList();
    }
}