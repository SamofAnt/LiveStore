using Microsoft.EntityFrameworkCore;

namespace LiveStore.ORM.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly StoreContext _context;

    public CategoryRepository(StoreContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Category> GetById(int id)
    {
        return await _context.Categories.FirstAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> FindById(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
    }

    public bool TryGet(int id, out Category? category)
    {
        category = FindById(id).Result;
        return category != null;
    }

    public async Task Add(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}