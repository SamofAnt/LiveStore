namespace LiveStore.Data.Model;

public class ObservableBasket : IBasket
{
    private readonly IBasket _originalBasket;

    public ObservableBasket(IBasket originalBasket)
    {
        _originalBasket = originalBasket;
    }

    public int ItemsCount => _originalBasket.ItemsCount;
    public decimal TotalAmount => _originalBasket.TotalAmount;

    public IReadOnlyDictionary<Product, int> GetBasketProducts()
    {
        return _originalBasket.GetBasketProducts();
    }

    public void Add(Product product)
    {
        _originalBasket.Add(product);
        OnChanged?.Invoke();
    }

    public bool Remove(Product product)
    {
        var result = _originalBasket.Remove(product);
        OnChanged?.Invoke();
        return result;
    }

    public void Clear()
    {
        _originalBasket.Clear();
        OnChanged?.Invoke();
    }

    public virtual event Action? OnChanged;
}