using Amazon.Data.Model;

namespace Amazon.Data.Interfaces;

public interface ICatalog
{
    public IReadOnlyCollection<Product> GetProducts();
}