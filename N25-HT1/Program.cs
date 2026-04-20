// ───────────────────────────────────────────────
//  Dependency yaratish
// ───────────────────────────────────────────────
using N25_HT1.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

IProductService productService = new ProductService();
IPaymentService paymentService = new PaymentService();
IOrderService orderService = new OrderService(productService, paymentService);

// ───────────────────────────────────────────────
//  10 ta mahsulot qo'shish
// ───────────────────────────────────────────────
productService.Add(new Laptop
{
    Id = 1,
    Name = "Dell XPS 15",
    Description = "Premium laptop",
    Price = 1500,
    CpuBrand = "Intel",
    CpuModel = "Core i7-13700H"
});
productService.Add(new Laptop
{
    Id = 2,
    Name = "MacBook Pro 14",
    Description = "Apple silicon",
    Price = 2200,
    CpuBrand = "Apple",
    CpuModel = "M3 Pro"
});
productService.Add(new Laptop
{
    Id = 3,
    Name = "Lenovo ThinkPad X1",
    Description = "Business laptop",
    Price = 1300,
    CpuBrand = "Intel",
    CpuModel = "Core i5-1335U"
});
productService.Add(new Chair
{
    Id = 4,
    Name = "ErgoMax Pro",
    Description = "Ergonomic office chair",
    Price = 450,
    MaxWeight = 130,
    Material = "Mesh"
});
productService.Add(new Chair
{
    Id = 5,
    Name = "ComfortPlus",
    Description = "Budget office chair",
    Price = 180,
    MaxWeight = 110,
    Material = "Fabric"
});
productService.Add(new Chair
{
    Id = 6,
    Name = "HermanMiller Aeron",
    Description = "Premium ergonomic",
    Price = 1200,
    MaxWeight = 150,
    Material = "Polymer Mesh"
});
productService.Add(new Monitor
{
    Id = 7,
    Name = "LG UltraWide 34",
    Description = "Ultrawide monitor",
    Price = 700,
    DisplaySize = 34.0,
    RefreshRate = 144
});
productService.Add(new Monitor
{
    Id = 8,
    Name = "Samsung Odyssey G7",
    Description = "Gaming monitor",
    Price = 550,
    DisplaySize = 27.0,
    RefreshRate = 240
});
productService.Add(new Monitor
{
    Id = 9,
    Name = "Dell U2723D",
    Description = "4K UHD office monitor",
    Price = 620,
    DisplaySize = 27.0,
    RefreshRate = 60
});
productService.Add(new Monitor
{
    Id = 10,
    Name = "AOC 24G2",
    Description = "Budget gaming monitor",
    Price = 220,
    DisplaySize = 23.8,
    RefreshRate = 144
});

// ───────────────────────────────────────────────
//  Mavjud mahsulot turlarini ko'rsatish
// ───────────────────────────────────────────────
Console.WriteLine("════════════════════════════════════════");
Console.WriteLine("  📦 Mavjud mahsulot turlari:");
Console.WriteLine("════════════════════════════════════════");

var filterData = productService.GetFilterData();
foreach (var type in filterData.ProductTypes)
    Console.WriteLine($"  • {type}");

// ───────────────────────────────────────────────
//  Debit karta yaratish
// ───────────────────────────────────────────────
var card = new DebitCard("8600123456789012", balance: 2000);

Console.WriteLine("\n════════════════════════════════════════");
Console.WriteLine($"  💳 Karta holati: {card}");
Console.WriteLine("════════════════════════════════════════");

// ═══════════════════════════════════════════
//  TEST 1: Muvaffaqiyatli bitta mahsulot xarid
// ═══════════════════════════════════════════
Console.WriteLine("\n▶ TEST 1: Bitta laptop xarid (Id=3, $1300) — karta: $2000");
bool result1 = orderService.Order(3, card);
Console.WriteLine($"  Natija: {(result1 ? "✅ Muvaffaqiyatli" : "❌ Amalga oshmadi")}");
Console.WriteLine($"  💳 Karta holati: {card}");

// ═══════════════════════════════════════════
//  TEST 2: Pul yetarli emas — bitta mahsulot
// ═══════════════════════════════════════════
Console.WriteLine("\n▶ TEST 2: Qimmat laptop xarid (Id=2, $2200) — karta: $700 qolgan");
bool result2 = orderService.Order(2, card);
Console.WriteLine($"  Natija: {(result2 ? "✅ Muvaffaqiyatli" : "❌ Amalga oshmadi")}");
Console.WriteLine($"  💳 Karta holati: {card}");

// ═══════════════════════════════════════════
//  TEST 3: Mavjud bo'lmagan product id
// ═══════════════════════════════════════════
Console.WriteLine("\n▶ TEST 3: Mavjud bo'lmagan mahsulot (Id=99)");
bool result3 = orderService.Order(99, card);
Console.WriteLine($"  Natija: {(result3 ? "✅ Muvaffaqiyatli" : "❌ Amalga oshmadi")}");

// ═══════════════════════════════════════════
//  TEST 4: Filter bo'yicha bir nechta xarid — muvaffaqiyatli
// ═══════════════════════════════════════════
Console.WriteLine("\n▶ TEST 4: Barcha 'Chair' larni xarid (jami: $1830) — karta: $700 qolgan");

// Avval kartani to'ldiramiz test uchun
card.Balance = 2000;
Console.WriteLine($"  💳 Karta to'ldirildi: {card}");

var chairFilter = new ProductFilterModel
{
    Type = typeof(Chair).FullName  // "Chair" type bo'yicha filter
};

bool result4 = orderService.Order(chairFilter, card);
Console.WriteLine($"  Natija: {(result4 ? "✅ Muvaffaqiyatli" : "❌ Amalga oshmadi")}");
Console.WriteLine($"  💳 Karta holati: {card}");

// ═══════════════════════════════════════════
//  TEST 5: Filter bo'yicha — pul yetarli emas, rollback
// ═══════════════════════════════════════════
Console.WriteLine("\n▶ TEST 5: 'Monitor' larni xarid (jami: $2090) — karta: $170 qolgan");

var monitorFilter = new ProductFilterModel
{
    Type = typeof(Monitor).FullName
};

bool result5 = orderService.Order(monitorFilter, card);
Console.WriteLine($"  Natija: {(result5 ? "✅ Muvaffaqiyatli" : "❌ Amalga oshmadi")}");
Console.WriteLine($"  💳 Karta holati: {card}");

// ═══════════════════════════════════════════
//  TEST 6: Nom bo'yicha filter
// ═══════════════════════════════════════════
Console.WriteLine("\n▶ TEST 6: 'Samsung' nomi bo'yicha filter xarid");

card.Balance = 1000;
Console.WriteLine($"  💳 Karta to'ldirildi: {card}");

var nameFilter = new ProductFilterModel { Name = "Samsung" };
bool result6 = orderService.Order(nameFilter, card);
Console.WriteLine($"  Natija: {(result6 ? "✅ Muvaffaqiyatli" : "❌ Amalga oshmadi")}");
Console.WriteLine($"  💳 Karta holati: {card}");

// ═══════════════════════════════════════════
//  Final: Inventory holati
// ═══════════════════════════════════════════
Console.WriteLine("\n════════════════════════════════════════");
Console.WriteLine("  📋 Inventory yakuniy holati:");
Console.WriteLine("════════════════════════════════════════");
foreach (var p in productService.Inventory)
    Console.WriteLine($"  {p}");