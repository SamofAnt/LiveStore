namespace LiveStore.Data.Model;

public class Product
{
    public Product(Guid Id, int CategoryId, string Name, decimal Price, string Image, string Description)
    {
        this.Id = Id;   
        this.CategoryId = CategoryId;
        this.Name = Name;
        this.Price = Price;
        this.Image = Image;
        this.Description = Description;
    }

    public static Product Empty { get; } = new(new Guid(), 0, "Нет", 0m, "", "");
    public Guid Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
}