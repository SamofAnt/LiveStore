using LiveStore.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace LiveStore.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Product> GetById(int id)
    {
        return await _context.Products.FirstAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetAllByCategoryId(int id)
    {
        return await _context.Products.Where(p => p.CategoryId == id).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> FindById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public bool TryGet(int id, out Product? product)
    {
        product = FindById(id).Result;
        return product != null;
    }


    public async Task Add(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Remove(int id)
    {
        if (!TryGet(id, out var product))
            return false;
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}