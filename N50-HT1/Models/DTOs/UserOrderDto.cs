namespace N50_HT1.Models.DTOs;

public class UserOrderDto
{
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<OrderDto> Orders { get; set; } = new();
}
