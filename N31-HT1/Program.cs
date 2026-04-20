using System.Text.Json;
using System.IO;

// 1. Dastlabki bazani sozlash (Agar fayllar bo'lmasa, yaratadi)
SetupDatabase();

// 2. Fayllardan ma'lumotlarni o'qib olish
var customersJson = File.ReadAllText("customers.json");
var ordersJson = File.ReadAllText("orders.json");

var customers = JsonSerializer.Deserialize<List<Customer>>(customersJson);
var orders = JsonSerializer.Deserialize<List<Order>>(ordersJson);

// 3. LINQ orqali filtr va hisobot tayyorlash
var currentYear = DateTime.Now.Year;
var currentMonth = DateTime.Now.Month;

var result = customers
    .Where(c => c.Country == Country.UK) // Faqat UK
    .GroupJoin(
        orders,
        customer => customer.Id,
        order => order.CustomerId,
        (customer, customerOrders) => new
        {
            Customer = customer,
            // Shu oyga tegishli va 5000 dan katta orderlar
            FilteredOrders = customerOrders.Where(o =>
                o.OrderDate.Year == currentYear &&
                o.OrderDate.Month == currentMonth &&
                o.Amount >= 5000)
        })
    .Where(x => x.FilteredOrders.Any()) // Faqat orderi borlar
    .Select(x => new
    {
        CustomerName = $"{x.Customer.FirstName} {x.Customer.LastName}",
        Country = x.Customer.Country.ToString(),
        Orders = x.FilteredOrders.Select(o => new
        {
            o.Id,
            o.Amount,
            Date = o.OrderDate.ToString("d")
        })
    })
    .ToList();

// 4. Natijani report.json fayliga yozish
string finalReport = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("report.json", finalReport);

Console.WriteLine("Ma'lumotlar o'qildi, filtrlash tugadi va 'report.json' yaratildi.");
Console.WriteLine("\n--- Hisobot ---");
Console.WriteLine(finalReport);


// --- Yordamchi Metodlar ---

void SetupDatabase()
{
    // Agar fayllar allaqachon mavjud bo'lsa, qayta yaratmaymiz
    if (File.Exists("customers.json") && File.Exists("orders.json")) return;

    var initialCustomers = new List<Customer>
{
    new(1, "John", "Smith", Country.Uzbekistan),
    new(2, "Jane", "Johnson", Country.USA),
    new(3, "Michael", "Brown", Country.UK), // Target
    new(4, "David", "Lee", Country.Germany),
    new(5, "Sarah", "Wilson", Country.France),
    new(6, "Emily", "Davis", Country.Japan),
    new(7, "William", "Garcia", Country.China),
    new(8, "James", "Miller", Country.Russia),
    new(9, "Olivia", "Jones", Country.Brazil),
    new(10, "Emma", "Taylor", Country.Australia),
    new(11, "Daniel", "Anderson", Country.Uzbekistan),
    new(12, "Sophia", "Thomas", Country.USA),
    new(13, "Matthew", "Jackson", Country.UK), // Target
    new(14, "Ava", "White", Country.Germany),
    new(15, "Ethan", "Harris", Country.France),
    new(16, "Isabella", "Martin", Country.Japan),
    new(17, "Noah", "Thompson", Country.China),
    new(18, "Mia", "Moore", Country.Russia),
    new(19, "Liam", "Allen", Country.Brazil),
    new(20, "Charlotte", "Young", Country.Australia),
    new(21, "Lucas", "King", Country.Uzbekistan),
    new(22, "Amelia", "Wright", Country.USA),
    new(23, "William", "Baker", Country.UK), // Target
    new(24, "Abigail", "Nelson", Country.Germany),
    new(25, "Alexander", "Carter", Country.France),
    new(26, "Emily", "Mitchell", Country.Japan),
    new(27, "Benjamin", "Perez", Country.China),
    new(28, "Chloe", "Roberts", Country.Russia),
    new(29, "Michael", "Turner", Country.Brazil),
    new(30, "Ella", "Phillips", Country.Australia),
    new(31, "William", "Campbell", Country.Uzbekistan),
    new(32, "Victoria", "Parker", Country.USA),
    new(33, "James", "Evans", Country.UK), // Target
    new(34, "Grace", "Edwards", Country.Germany),
    new(35, "Daniel", "Collins", Country.France),
    new(36, "Madison", "Stewart", Country.Japan),
    new(37, "Joseph", "Sanchez", Country.China),
    new(38, "Avery", "Morris", Country.Russia),
    new(39, "David", "Rogers", Country.Brazil),
    new(40, "Sofia", "Reed", Country.Australia)
};

    var initialOrders = new List<Order>
{
    // Hisobotga KIRADIGANLAR (UK, 2026 Aprel, > 5000)
    new(1, 3, 9450, new DateTime(2026, 4, 12)),
    new(2, 3, 7200, new DateTime(2026, 4, 5)),
    new(3, 13, 8500, new DateTime(2026, 4, 15)),
    new(4, 23, 6100, new DateTime(2026, 4, 20)),
    new(5, 33, 9900, new DateTime(2026, 4, 25)),
    new(6, 3, 5050, new DateTime(2026, 4, 1)),
    
    // UK lekin summasi kichik (Kirmaydi)
    new(7, 13, 1200, new DateTime(2026, 4, 10)),
    new(8, 23, 4500, new DateTime(2026, 4, 18)),
    
    // UK lekin sanasi boshqa oy (Kirmaydi)
    new(9, 33, 7000, new DateTime(2026, 3, 28)),
    new(10, 3, 8000, new DateTime(2026, 5, 2)),

    // Boshqa davlatlar (Kirmaydi)
    new(11, 1, 9000, new DateTime(2026, 4, 10)), // Uzbekistan
    new(12, 2, 6500, new DateTime(2026, 4, 11)), // USA
    new(13, 4, 5500, new DateTime(2026, 4, 12)), // Germany
    new(14, 5, 7800, new DateTime(2026, 4, 13)), // France
    new(15, 6, 9200, new DateTime(2026, 4, 14)), // Japan
    new(16, 7, 4000, new DateTime(2026, 4, 15)), // China
    new(17, 8, 8100, new DateTime(2026, 4, 16)), // Russia
    new(18, 9, 5200, new DateTime(2026, 4, 17)), // Brazil
    new(19, 10, 6300, new DateTime(2026, 4, 18)), // Australia
    new(20, 11, 7100, new DateTime(2026, 4, 19)), // Uzbekistan
    new(21, 12, 8800, new DateTime(2026, 4, 20)), // USA
    new(22, 14, 3000, new DateTime(2026, 4, 21)), // Germany
    new(23, 15, 9500, new DateTime(2026, 4, 22)), // France
    new(24, 16, 4800, new DateTime(2026, 4, 23)), // Japan
    new(25, 17, 5600, new DateTime(2026, 4, 24)), // China
    new(26, 18, 7200, new DateTime(2026, 4, 25)), // Russia
    new(27, 19, 9100, new DateTime(2026, 4, 26)), // Brazil
    new(28, 20, 4400, new DateTime(2026, 4, 27)), // Australia
    new(29, 21, 8200, new DateTime(2026, 4, 28)), // Uzbekistan
    new(30, 22, 6000, new DateTime(2026, 4, 29)), // USA
    new(31, 24, 3900, new DateTime(2026, 4, 30)), // Germany
    new(32, 25, 9990, new DateTime(2026, 4, 5)),  // France
    new(33, 26, 5100, new DateTime(2026, 4, 6)),  // Japan
    new(34, 27, 7300, new DateTime(2026, 4, 7)),  // China
    new(35, 28, 8400, new DateTime(2026, 4, 8)),  // Russia
    new(36, 29, 2200, new DateTime(2026, 4, 9)),  // Brazil
    new(37, 30, 6700, new DateTime(2026, 4, 10)), // Australia
    new(38, 31, 5400, new DateTime(2026, 4, 11)), // Uzbekistan
    new(39, 32, 8300, new DateTime(2026, 4, 12)), // USA
    new(40, 34, 7600, new DateTime(2026, 4, 13))  // Germany
};

    File.WriteAllText("customers.json", JsonSerializer.Serialize(initialCustomers));
    File.WriteAllText("orders.txt", JsonSerializer.Serialize(initialOrders)); // text file sifatida ham saqlash mumkin
    File.WriteAllText("orders.json", JsonSerializer.Serialize(initialOrders));
}

// --- Modellar ---

public enum Country { Uzbekistan, China, Russia, Brazil, Australia, Germany, France, Japan, UK, USA }

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Country Country { get; set; }

    public Customer(int id, string firstName, string lastName, Country country)
    {
        Id = id; FirstName = firstName; LastName = lastName; Country = country;
    }
}

public class Order
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }

    public Order(int id, int customerId, int amount, DateTime orderDate)
    {
        Id = id; Amount = amount; CustomerId = customerId; OrderDate = orderDate;
    }
}