public interface IProduct
{
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    bool IsOrdered { get; set; }
    decimal Price { get; set; }
}