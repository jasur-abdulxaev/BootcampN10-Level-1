using N25_HT1.Services;

public class ProductService : IProductService
{
    // Ichki ro'yxat — tashqaridan to'g'ridan to'g'ri o'zgartirib bo'lmaydi
    private readonly List<IProduct> _inventory = new();

    public IEnumerable<IProduct> Inventory => _inventory;

    // --- Add ---
    public void Add(IProduct product)
    {
        _inventory.Add(product);
    }

    // --- GetFilterData ---
    public ProductFilterDataModel GetFilterData()
    {
        // Hech product yo'q bo'lsa — empty model qaytaradi
        if (!_inventory.Any())
            return new ProductFilterDataModel();

        return new ProductFilterDataModel
        {
            // Unique type nomlarini olish
            ProductTypes = _inventory
                .Select(item => item.GetType().FullName!)
                .Distinct()
                .ToList()
        };
    }

    // --- Get (filter bo'yicha, copy qaytaradi) ---
    public IEnumerable<IProduct> Get(ProductFilterModel filterModel)
    {
        IEnumerable<IProduct> query = _inventory;

        // Nom bo'yicha filter (case-insensitive, qisman moslik)
        if (!string.IsNullOrWhiteSpace(filterModel.Name))
            query = query.Where(p =>
                p.Name.Contains(filterModel.Name, StringComparison.OrdinalIgnoreCase));

        // Type bo'yicha filter (GetType().FullName exact match)
        if (!string.IsNullOrWhiteSpace(filterModel.Type))
            query = query.Where(p =>
                p.GetType().FullName == filterModel.Type);

        // Har birining copy constructor orqali nusxasini qaytarish
        return query.Select(CreateCopy).ToList();
    }

    // --- Order (isOrdered = true, copy qaytaradi) ---
    public IProduct Order(int productId)
    {
        var product = FindOrThrow(productId);

        product.IsOrdered = true;   // real inventory objecti o'zgaradi

        return CreateCopy(product); // copy qaytariladi
    }

    // --- Return (isOrdered = false, copy qaytaradi) ---
    public IProduct Return(int productId)
    {
        var product = FindOrThrow(productId);

        product.IsOrdered = false;

        return CreateCopy(product);
    }

    // --- Private helpers ---

    private IProduct FindOrThrow(int id)
    {
        return _inventory.FirstOrDefault(p => p.Id == id)
               ?? throw new KeyNotFoundException($"Product with Id={id} not found.");
    }

    // Concrete type ga qarab to'g'ri copy constructor chaqiriladi
    private static IProduct CreateCopy(IProduct product)
    {
        return product switch
        {
            Laptop l => new Laptop(l),
            Chair c => new Chair(c),
            Monitor m => new Monitor(m),
            _ => throw new NotSupportedException(
                     $"Copy not supported for type: {product.GetType().Name}")
        };
    }
}