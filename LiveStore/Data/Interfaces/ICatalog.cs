using LiveStore.Data.Model;

namespace LiveStore.Data.Interfaces;

public interface ICatalog
{
    public IReadOnlyCollection<Product> GetProducts();
}