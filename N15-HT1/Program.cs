using N15_HT1;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("╔════════════════════════════════════════════════╗");
Console.WriteLine("║        OB-HAVO MA'LUMOTLARI TIZIMI             ║");
Console.WriteLine("╚════════════════════════════════════════════════╝\n");

// ========== TEST 1: WeatherReport ==========
Console.WriteLine("═══ TEST 1: WeatherReport ═══\n");

WeatherReport basicReport = new WeatherReport();

// 6 ta ob-havo qo'shish
basicReport.Add(new DateTime(2026, 3, 8), "Quyoshli, +15°C");
basicReport.Add(new DateTime(2026, 3, 9), "Bulutli, +12°C");
basicReport.Add(new DateTime(2026, 3, 10), "Yomg'irli, +8°C");
basicReport.Add(new DateTime(2026, 3, 11), "Qorli, -2°C");
basicReport.Add(new DateTime(2026, 3, 12), "Quyoshli, +10°C");
basicReport.Add(new DateTime(2026, 3, 13), "Shamolli, +7°C");

// Mavjud sanani so'rash
Console.WriteLine("Mavjud sana (2026-03-10):");
string weather1 = basicReport.Get(new DateTime(2026, 3, 10));
Console.WriteLine($"  → {weather1}\n");

// Mavjud bo'lmagan sanani so'rash
Console.WriteLine("Mavjud bo'lmagan sana (2026-03-20):");
string weather2 = basicReport.Get(new DateTime(2026, 3, 20));
Console.WriteLine($"  → {weather2}\n");

// ========== TEST 2: ValidatedWeatherReport ==========
Console.WriteLine("\n═══ TEST 2: ValidatedWeatherReport ═══\n");

ValidatedWeatherReport validatedReport = new ValidatedWeatherReport();

// 6 ta qo'shish (2 tasi bir xil sana)
validatedReport.Add(new DateTime(2026, 3, 8), "Quyoshli, +15°C");
validatedReport.Add(new DateTime(2026, 3, 9), "Bulutli, +12°C");
validatedReport.Add(new DateTime(2026, 3, 8), "Juda quyoshli, +18°C"); // Takror!
validatedReport.Add(new DateTime(2026, 3, 10), "Yomg'irli, +8°C");
validatedReport.Add(new DateTime(2026, 3, 11), "Qorli, -2°C");
validatedReport.Add(new DateTime(2026, 3, 9), "Ochiq havo, +14°C"); // Takror!

Console.WriteLine("\nYangilangan ma'lumot (2026-03-08):");
Console.WriteLine($"  → {validatedReport.Get(new DateTime(2026, 3, 8))}\n");

// ========== TEST 3: UltimateWeatherReport ==========
Console.WriteLine("\n═══ TEST 3: UltimateWeatherReport ═══\n");

UltimateWeatherReport ultimateReport = new UltimateWeatherReport();

// 10 ta ob-havo qo'shish
Console.WriteLine("10 ta ob-havo ma'lumotini qo'shish:\n");
ultimateReport.Add(new DateTime(2026, 3, 7), "Quyoshli, +13°C");
ultimateReport.Add(new DateTime(2026, 3, 8), "Bulutli, +15°C");
ultimateReport.Add(new DateTime(2026, 3, 9), "Yomg'irli, +10°C");
ultimateReport.Add(new DateTime(2026, 3, 10), "Qorli, +2°C");
ultimateReport.Add(new DateTime(2026, 3, 11), "Ochiq, +12°C");
ultimateReport.Add(new DateTime(2026, 3, 12), "Shamolli, +8°C");
ultimateReport.Add(new DateTime(2026, 3, 13), "Quyoshli, +16°C");
ultimateReport.Add(new DateTime(2026, 3, 14), "Bulutli, +14°C");
ultimateReport.Add(new DateTime(2026, 3, 15), "Yomg'irli, +9°C");
ultimateReport.Add(new DateTime(2026, 3, 16), "Quyoshli, +17°C");

// Get(sana, kunlar) - to'liq ma'lumot bor
Console.WriteLine("\n--- 2026-03-08 dan 5 kun uchun ---");
List<string> forecast1 = ultimateReport.Get(new DateTime(2026, 3, 8), 5);
if (forecast1.Count > 0)
{
    foreach (string item in forecast1)
    {
        Console.WriteLine($"  📅 {item}");
    }
}

// Get(sana, kunlar) - to'liq ma'lumot yo'q
Console.WriteLine("\n--- 2026-03-15 dan 5 kun uchun (to'liq yo'q) ---");
List<string> forecast2 = ultimateReport.Get(new DateTime(2026, 3, 15), 5);

// Get(kunlar) - bugundan boshlab
Console.WriteLine("\n--- Bugundan 3 kun uchun ---");
List<string> forecast3 = ultimateReport.Get(3);
if (forecast3.Count > 0)
{
    foreach (string item in forecast3)
    {
        Console.WriteLine($"  📅 {item}");
    }
}
else
{
    Console.WriteLine("  (Bugun uchun ma'lumot yo'q)");
}

Console.WriteLine("\n╔════════════════════════════════════════════════╗");
Console.WriteLine("║              Dastur tugadi                     ║");
Console.WriteLine("╚════════════════════════════════════════════════╝");

Console.ReadKey();