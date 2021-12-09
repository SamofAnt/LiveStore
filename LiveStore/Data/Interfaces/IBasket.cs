using LiveStore.Data.Model;

namespace LiveStore.Data;

public interface IBasket
{
    int ItemsCount { get; }
    decimal TotalAmount { get; }
    IReadOnlyDictionary<Product, int> GetBasketProducts();
    void Add(Product product);
    bool Remove(Product product);
    void Clear();
}