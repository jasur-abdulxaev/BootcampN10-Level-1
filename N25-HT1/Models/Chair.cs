public class Chair : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsOrdered { get; set; }
    public decimal Price { get; set; }

    // Chair-specific
    public double MaxWeight { get; set; }
    public string Material { get; set; }

    public Chair() { }

    public Chair(Chair other)
    {
        Id = other.Id;
        Name = other.Name;
        Description = other.Description;
        IsOrdered = other.IsOrdered;
        Price = other.Price;
        MaxWeight = other.MaxWeight;
        Material = other.Material;
    }

    public override string ToString()
        => $"[Chair] {Name} | {Material}, {MaxWeight}kg | ${Price} | Ordered: {IsOrdered}";
}