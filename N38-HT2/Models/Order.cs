namespace N38_HT2.Models;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateOnly OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }

    public override string ToString()
    {
        return $"Order ID: {Id}, Customer ID: {CustomerId}, Order Date: {OrderDate}, Total Amount: {TotalAmount}, Status: {Status}";
    }
}
