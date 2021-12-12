using LiveStore.Data.Model;

namespace LiveStore.ORM.Repositories;

class ProductRepository : IRepository<Product>
{
    private StoreContext _context;

    public ProductRepository(StoreContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Product GetById(Guid id)
    {
        return this.GetAll().SingleOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> GetAll() => _context.Products;

    public Product AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChangesAsync();
        return product;
    }
}