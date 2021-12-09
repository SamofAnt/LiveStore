namespace LiveStore.Data.Model;

public class InMemoryBasket : IBasket
{
    private readonly object _mutex = new();
    private Dictionary<Product, int> _products = new();

    public int ItemsCount => _products?.Sum(p => p.Value) ?? 0;

    public decimal TotalAmount => _products?.Sum(p => p.Key.Price * p.Value) ?? 0;

    public IReadOnlyDictionary<Product, int> GetBasketProducts()
    {
        return _products;
    }

    public void Add(Product product)
    {
        lock (_mutex)
        {
            if (_products.TryGetValue(product, out var quantity))
                _products[product] = quantity + 1;
            else
                _products.Add(product, 1);
            MoveProductToBegin(product);
        }
    }

    public bool Remove(Product product)
    {
        lock (_mutex)
        {
            if (!_products.ContainsKey(product))
                return false;

            _products[product]--;
            if (_products.TryGetValue(product, out var quantity) && quantity == 0)
                _products.Remove(product, out quantity);
        }

        return true;
    }

    public void Clear()
    {
        _products.Clear();
    }

    /// <summary>
    ///     Перемещает товар в самое начало списка
    /// </summary>
    private void MoveProductToBegin(Product product)
    {
        var newProducts = new Dictionary<Product, int>
        {
            [product] = _products[product]
        };
        foreach (var (key, value) in _products)
            if (key != product)
                newProducts.Add(key, value);

        _products = newProducts;
    }
}