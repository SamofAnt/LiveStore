using LiveStore.Data.Interfaces;
using LiveStore.Data.Model;
using Microsoft.AspNetCore.Components;

namespace LiveStore.Pages;

public class CatalogRazor : ComponentBase
{
    protected IReadOnlyCollection<Product> _products = new List<Product>();

    [Parameter] public int CategoryId { get; set; }

    [Inject] private ICatalog CatalogProducts { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _products = CatalogProducts.GetProducts();
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        _products = CatalogProducts.GetProducts().Where(p => p.CategoryId == CategoryId).ToList();
    }
}