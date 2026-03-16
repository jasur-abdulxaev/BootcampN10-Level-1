using N22_T1.Interfaces;

namespace N22_T1.Models
{
    public class Product : IProduct
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }


        public Product(int id, string name, decimal price, int stock, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Category = category;
        }

        public void Display()
        {
            Console.WriteLine($"[{Id}] {Name} - ${Price:F2}");
            Console.WriteLine($"    Category: {Category}, Stock: {Stock}");
        }

        public bool IsAvailable()
        {
            return Stock > 0;
        }
    }
}

