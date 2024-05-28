namespace sda_onsite_2_csharp_backend_teamwork.src.Entities;

public class Stock
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int StockQuantity { get; set; }
    public int Price { get; set; }
    public string? Color { get; set; }
    public char? Size { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
}
