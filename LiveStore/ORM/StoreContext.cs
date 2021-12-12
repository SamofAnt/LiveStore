using LiveStore.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace LiveStore.ORM;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}