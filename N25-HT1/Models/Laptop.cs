public class Laptop : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsOrdered { get; set; }
    public decimal Price { get; set; }

    // Laptop-specific
    public string CpuBrand { get; set; }
    public string CpuModel { get; set; }

    public Laptop() { }

    // Copy constructor — inventory ichidagi real objectni o'zgartirmaslik uchun
    public Laptop(Laptop other)
    {
        Id = other.Id;
        Name = other.Name;
        Description = other.Description;
        IsOrdered = other.IsOrdered;
        Price = other.Price;
        CpuBrand = other.CpuBrand;
        CpuModel = other.CpuModel;
    }

    public override string ToString()
        => $"[Laptop] {Name} | CPU: {CpuBrand} {CpuModel} | ${Price} | Ordered: {IsOrdered}";
}