using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace LiveStore.Data.Model;

public class LocalStorageBasket : IBasket
{
    private readonly ProtectedLocalStorage _localStorage;
    private readonly IBasket _originalBasket;

    public LocalStorageBasket(IBasket originalBasket, ProtectedLocalStorage localStorage)
    {
        _originalBasket = originalBasket;
        _localStorage = localStorage;
    }

    public int ItemsCount => _originalBasket.ItemsCount;
    public decimal TotalAmount => _originalBasket.TotalAmount;

    public IReadOnlyDictionary<Product, int>? GetBasketProducts()
    {
        return _originalBasket.GetBasketProducts();
    }

    public void Add(Product product)
    {
        _originalBasket.Add(product);
        SaveBasketAsync();
    }

    public bool Remove(Product product)
    {
        var result = _originalBasket.Remove(product);
        SaveBasketAsync();
        return result;
    }

    public void Clear()
    {
        _originalBasket.Clear();
        SaveBasketAsync();
    }

    private async Task SaveBasketAsync()
    {
        await _localStorage.SetAsync("basket", _localStorage);
    }
}