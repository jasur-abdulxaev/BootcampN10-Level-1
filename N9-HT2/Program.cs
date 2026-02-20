using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// 1. Ma'lumotlar — alohida
static List<(string Name, DateTime Time)> GetEvents()
{
    int year = DateTime.Now.Year;
    return new List<(string Name, DateTime Time)>
    {
        // 🇺🇿 O'zbek bayramlari
        ("O'zbekiston Mustaqillik Kuni",   new DateTime(year, 9,  1,  12, 30, 0)),
        ("O'zbekiston Konstitutsiya Kuni", new DateTime(year, 12, 8,  9,  0,  0)),

        // 🇷🇺 Rus bayramlari
        ("Rossiya Milliy Birligi Kuni",    new DateTime(year, 11, 4,  10, 0,  0)),
        ("Rossiya Mustaqillik Kuni",       new DateTime(year, 6,  12, 11, 0,  0)),

        // 🇺🇸 Amerika bayramlari
        ("USA Independence Day",           new DateTime(year, 7,  4,  9,  0,  0)),
        ("USA Thanksgiving Day",           GetThanksgiving(year)),  // ✅ dinamik

        // 🌍 Xalqaro bayramlar
        ("Xalqaro Xotin-Qizlar Kuni",     new DateTime(year, 3,  8,  10, 0,  0)),
        ("Xalqaro Mehnat Kuni",           new DateTime(year, 5,  1,  9,  0,  0)),
    };
}

// 2. Thanksgiving hisoblash — alohida
static DateTime GetThanksgiving(int year)
{
    var firstDay = new DateTime(year, 11, 1);
    int daysUntilThursday = ((int)DayOfWeek.Thursday - (int)firstDay.DayOfWeek + 7) % 7;
    return firstDay.AddDays(daysUntilThursday + 21).Add(new TimeSpan(15, 0, 0));
}

// 3. Formatlash — alohida
static string FormatEvent(string name, DateTime time, string format, CultureInfo culture)
{
    return $"{name,-40} - {time.ToString(format, culture)}";
}

// 4. Chiqarish — alohida
static void PrintEvents(List<(string Name, DateTime Time)> events, string lang)
{
    // ✅ Key ishlatilmoqda — to'g'ridan-to'g'ri murojaat
    var cultures = new Dictionary<string, (string Format, CultureInfo Culture)>
    {
        { "en", ("MM.dd.yyyy hh:mm tt", new CultureInfo("en-US")) },
        { "ru", ("dd/MM/yyyy HH:mm",    new CultureInfo("ru-RU")) },
        { "uz", ("dd.MM.yyyy HH:mm",    new CultureInfo("uz-UZ")) }
    };

    if (!cultures.ContainsKey(lang))
    {
        Console.WriteLine($"  [{lang}] — noma'lum til!");
        return;
    }

    var (format, culture) = cultures[lang]; // ✅ Key ishlatildi

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"\n  [{lang.ToUpper()}]");
    Console.WriteLine("  " + new string('─', 60));
    Console.ResetColor();

    foreach (var (name, time) in events)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("  ✔ ");
        Console.ResetColor();
        Console.WriteLine(FormatEvent(name, time, format, culture));
    }
}

// 5. Asosiy kod — minimal va toza
var sortedEvents = GetEvents().OrderBy(e => e.Time).ToList();
var languages = new[] { "en", "ru", "uz" };

Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
Console.WriteLine("║               Xalqaro Bayramlar Jadvali 🌍                   ║");
Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");

foreach (var lang in languages)
    PrintEvents(sortedEvents, lang);

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"  Jami: {sortedEvents.Count} ta | Yil: {DateTime.Now.Year}");
Console.ResetColor();
Console.WriteLine("══════════════════════════════════════════════════════════════");