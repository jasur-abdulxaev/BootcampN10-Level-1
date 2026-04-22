namespace N50_HT1.Models.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}
