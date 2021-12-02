using System.Collections.Concurrent;

namespace Amazon.Data.Model;

public class InMemoryBasket : IBasket
{
    private readonly ConcurrentDictionary<Product, int> _products = new ConcurrentDictionary<Product, int>();
    
    public int ItemsCount => _products?.Sum(p => p.Value) ?? 0;

    public decimal TotalAmount => _products?.Sum(p => p.Key.Price * p.Value) ?? 0;
    public IReadOnlyDictionary<Product, int> GetBasketProducts() => _products;
    public Product Add(Product product)
    {
        if (_products.ContainsKey(product))
            _products[product]++;
        else
            _products.TryAdd(product, 1);
        return product;
    }

    public bool Remove(Product product)
    {
        if (!_products.ContainsKey(product))
            return false;
        _products[product]--;
        if (_products.TryGetValue(product, out int quantity) && quantity == 0)
            _products.Remove(product, out quantity);
        return true;
    }

    public void Clear() => _products.Clear();
}