using LiveStore.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiveStore.ORM.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.CategoryId).IsRequired();
        builder.Property(p => p.Name)
            .IsRequired();
        builder.Property(p => p.Price)
            .IsRequired();
        builder.HasIndex(p => p.Price);
    }
}