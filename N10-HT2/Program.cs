namespace ShoppingCart
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Product(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }

    public class ShoppingCart
    {
        public Dictionary<Product, int> Items { get; set; } = new Dictionary<Product, int>();

        public void Add(Product product)
        {
            foreach (var item in Items)
            {
                if (item.Key.Id == product.Id)
                {
                    Items[item.Key] = item.Value + 1;
                    return;
                }
            }

            Items[product] = 1;
        }

        public bool Remove(Product product)
        {
            foreach (var item in Items)
            {
                if (item.Key.Id == product.Id)
                {
                    Items[item.Key] = item.Value - 1;
                    return true;
                }
            }

            return false;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("HP Victus");
            Product product2 = new Product("IPhone 17");
            Product product3 = new Product("Phone Case");

            ShoppingCart cart = new ShoppingCart();

            cart.Add(product1);
            cart.Add(product2);
            cart.Add(product3);

            RunAddTest(cart, product1, "Mavjud mahsulotni qayta qo'shish");
            RunAddTest(cart, product2, "Mavjud mahsulotni qayta qo'shish");

            RunRemoveTest(cart, product1, "Mavjud mahsulotni o'chirish.");
            RunRemoveTest(cart, product3, "Mavjud mahsulotni o'chirish.");
            RunRemoveTest(cart, new Product("Kepka"), "Mavjud bo'lmagan mahsulotni o'chirish");

            PrintCart(cart);
        }

        static void RunAddTest(ShoppingCart cart, Product product, string description)
        {
            cart.Add(product);
            Console.WriteLine($"[Add] [{description}] ProductId: {product.Id} => Qo'shildi");
        }

        static void RunRemoveTest(ShoppingCart cart, Product product, string description)
        {
            bool result = cart.Remove(product);
            Console.WriteLine($"[Remove] [{description}] ProductId: {product.Id} => {(result ? "O'chirildi" : "Topilmadi")}");
        }

        static void PrintCart(ShoppingCart cart)
        {
            Console.WriteLine("\n   KORZINKA HOLATI");
            foreach (var item in cart.Items)
            {
                Console.WriteLine($"  {item.Key.Name} ({item.Key.Id}) => {item.Value} ta");
            }
        }
    }
}