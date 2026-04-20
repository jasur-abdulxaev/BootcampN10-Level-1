using N25_HT1.Services;

public class OrderService : IOrderService
{
    // Composition: ProductService va PaymentService tashqaridan inject qilinadi
    private readonly IProductService _productService;
    private readonly IPaymentService _paymentService;

    public OrderService(IProductService productService, IPaymentService paymentService)
    {
        _productService = productService;
        _paymentService = paymentService;
    }

    // --- Bitta mahsulot xarid ---
    public bool Order(int id, DebitCard card)
    {
        IProduct ordered;

        try
        {
            // 1. Mahsulotni band qil (isOrdered = true)
            ordered = _productService.Order(id);
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"  ⚠️  {ex.Message}");
            return false;
        }

        // 2. To'lovni amalga oshir
        if (!_paymentService.Checkout(ordered.Price, card))
        {
            // Pul yetarli emas — mahsulotni qaytarib qo'y
            _productService.Return(id);
            Console.WriteLine($"  ↩️  Mahsulot qaytarildi: {ordered.Name}");
            return false;
        }

        Console.WriteLine($"  🛒 Muvaffaqiyatli xarid: {ordered.Name}");
        return true;
    }

    // --- FilterModel bo'yicha bir nechta mahsulot xarid ---
    public bool Order(ProductFilterModel filterModel, DebitCard card)
    {
        // 1. Filter bo'yicha mahsulotlarni topish (copy list)
        var found = _productService.Get(filterModel).ToList();

        if (!found.Any())
        {
            Console.WriteLine("  ⚠️  Filter bo'yicha mahsulot topilmadi.");
            return false;
        }

        // 2. Topilgan har bir mahsulotni band qil
        var successfullyOrdered = new List<IProduct>();

        foreach (var product in found)
        {
            try
            {
                var ordered = _productService.Order(product.Id);
                successfullyOrdered.Add(ordered);
            }
            catch (KeyNotFoundException)
            {
                // Bu product allaqachon yo'q bo'lib qolgan bo'lsa — skip
            }
        }

        if (!successfullyOrdered.Any())
        {
            Console.WriteLine("  ⚠️  Hech bir mahsulotni band qilib bo'lmadi.");
            return false;
        }

        // 3. Jami summa
        decimal total = successfullyOrdered.Sum(p => p.Price);
        Console.WriteLine($"  💰 Jami to'lov: ${total} ({successfullyOrdered.Count} ta mahsulot)");

        // 4. To'lovni amalga oshir
        if (!_paymentService.Checkout(total, card))
        {
            // Pul yetarli emas — hammasini qaytarib qo'y
            foreach (var p in successfullyOrdered)
            {
                _productService.Return(p.Id);
                Console.WriteLine($"  ↩️  Qaytarildi: {p.Name}");
            }
            return false;
        }

        foreach (var p in successfullyOrdered)
            Console.WriteLine($"  🛒 Xarid qilindi: {p.Name}");

        return true;
    }
}