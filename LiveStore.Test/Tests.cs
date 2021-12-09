using System.Linq;
using LiveStore.Data;
using LiveStore.Data.Model;
using NUnit.Framework;

namespace LiveStore.Test;

public class Tests
{
    private IBasket _basket = null!;
    private Product _product = null!;

    [SetUp]
    public void Setup()
    {
        _basket = new InMemoryBasket();
        _product = new Product(1, "Test", 0m, "", "");
    }

    [Test]
    public void Product_is_added_to_basket_success()
    {
        _basket.Add(_product);
        Assert.AreEqual(1, _basket.ItemsCount);
        Assert.AreEqual(1, _basket.GetBasketProducts().First().Key.Id);
    }

    [Test]
    public void Product_is_removed_from_basket_success()
    {
        _basket.Add(_product);
        Assert.IsTrue(_basket.Remove(_product));
        Assert.AreEqual(0, _basket.ItemsCount);
    }

    [Test]
    public void Product_is_removed_from_basket_fail()
    {
        Assert.IsFalse(_basket.Remove(_product));
    }
}