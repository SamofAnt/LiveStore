using LiveStore.Data.Model;
using LiveStore.ORM.Repositories;
using Microsoft.AspNetCore.Components;

namespace LiveStore.Pages;

public partial class Catalog
{
    private double _maxPrice;
    private IReadOnlyCollection<Product> _products = new List<Product>();

    [Parameter] public int CategoryId { get; set; }

    [Inject] private ICategoryRepository CategoriesRepository { get; set; }

    [Inject] private IProductRepository ProductsRepository { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _products = ProductsRepository.GetAll().Result.ToList();
    }
    
    private async Task OnChanged((double, double) args)
    {
        _products = ProductsRepository.GetAllByCategoryId(CategoryId).Result
            .Where(p => p.Price >= Convert.ToDecimal(args.Item1) && p.Price <= Convert.ToDecimal(args.Item2)).ToList();
        await InvokeAsync(StateHasChanged);
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        _products = ProductsRepository.GetAllByCategoryId(CategoryId).Result.ToList();
        _maxPrice = Convert.ToDouble(_products.Max(p => p.Price));
    }
}