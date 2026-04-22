namespace N50_HT1.Models.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}
