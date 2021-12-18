using System.Reflection;
using LiveStore.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace LiveStore.ORM;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        var categories = new Category[]
        {
            new("Смартфоны и гаджеты") {Id = 1},
            new("Телевизоры") {Id = 2},
            new("Техника для кухни") {Id = 3},
            new("Игры и софт") {Id = 4}
        };
        modelBuilder.Entity<Category>().HasData(categories);
    }
}