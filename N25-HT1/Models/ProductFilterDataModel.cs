public class ProductFilterDataModel
{
    // Inventorydagi barcha unique product type nomlari
    // collection.Select(item => item.GetType().FullName) orqali olinadi
    public IEnumerable<string> ProductTypes { get; set; }

    public ProductFilterDataModel()
    {
        ProductTypes = new List<string>(); // default: empty
    }
}