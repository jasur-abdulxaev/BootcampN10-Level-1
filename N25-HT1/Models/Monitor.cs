public class Monitor : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsOrdered { get; set; }
    public decimal Price { get; set; }

    // Monitor-specific
    public double DisplaySize { get; set; }
    public int RefreshRate { get; set; }

    public Monitor() { }

    public Monitor(Monitor other)
    {
        Id = other.Id;
        Name = other.Name;
        Description = other.Description;
        IsOrdered = other.IsOrdered;
        Price = other.Price;
        DisplaySize = other.DisplaySize;
        RefreshRate = other.RefreshRate;
    }

    public override string ToString()
        => $"[Monitor] {Name} | {DisplaySize}\" {RefreshRate}Hz | ${Price} | Ordered: {IsOrdered}";
}