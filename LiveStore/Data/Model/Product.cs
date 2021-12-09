namespace LiveStore.Data.Model;

public record Product(int Id, string Name, decimal Price, string Image, string Description)
{
    public static Product Empty { get; } = new(0, "Нет", 0m, "", "");
}