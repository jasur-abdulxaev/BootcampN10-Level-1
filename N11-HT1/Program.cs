// ToDo model
class ToDo
{
    public string Name { get; set; }
    public bool IsDone { get; set; }

    public ToDo(string name)
    {
        Name = name;
        IsDone = false;
    }
}

// ToDoList Service
class ToDoList
{
    private List<ToDo> _todos = new List<ToDo>();

    // Hamma vazifalarni ekranga chiqarish
    public void Display()
    {
        if (_todos.Count == 0)
        {
            Console.WriteLine("\n   Vazifalar ro'yhati bo'sh!\n");
            return;
        }

        Console.WriteLine(" === Vazifalar ro'yhati! ===");
        for (int i = 0; i < _todos.Count; i++)
        {
            string status = _todos[i].IsDone ? "[✔ ]" : "[  ]";
            Console.WriteLine($"    {i + 1}. {status} {_todos[i].Name}");
        }
        Console.WriteLine();
    }

    // Vazifani bajargan deb belgilash
    public void MarkDone()
    {
        if (_todos.Count == 0)
        {
            Console.WriteLine(" Vazifalar ro'yxati bo'sh!");
            return;
        }

        Console.WriteLine("\n   Qaysi vazifani tanlaysiz?");
        for (int i = 0; i < _todos.Count; i++)
        {
            string status = _todos[i].IsDone ? "[✔ ]" : "[  ]";
            Console.WriteLine($"    {i + 1}. {status} {_todos[i].Name}");
        }

        Console.Write(" Raqamni kiriting: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number) && number >= 1 && number <= _todos.Count)
        {
            _todos[number - 1].IsDone = true;
            Console.WriteLine($"\n  Vazifa \"{_todos[number - 1].Name}\" bajarilgan deb belgilandi!\n");
        }
        else
        {
            Console.WriteLine("\n   Noto'g'ri  raqam kiritildi!");
        }
    }

    // Yangi vazifa qo'shish
    public void Add()
    {
        Console.Write(" Vazifa nomini kiriting: ");
        string name = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(name))
        {
            _todos.Add(new ToDo(name));
            Console.WriteLine($"\n  Vazifa \"{name}\" qo'shildi!\n");
        }
        else
        {
            Console.WriteLine("\n   Vazifa nomi bo'sh bo'lishi mimkun emas!");
        }
    }
}

// Asosiy dastur
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ToDoList todoList = new ToDoList();

        Console.WriteLine(" === TODO LIST DASTUR! === ");

        while (true)
        {
            Console.WriteLine("  ─────────────────────────────────────");
            Console.Write("  Buyruq tanlang (display all - d / mark done - m / add - a / exit - e): ");
            string command = Console.ReadLine()?.Trim().ToLower();

            switch (command)
            {
                case "d":
                    todoList.Display();
                    break;
                case "m":
                    todoList.MarkDone();
                    break;
                case "a":
                    todoList.Add();
                    break;
                case "e":
                    Console.WriteLine(" Dastur tugadi. Xayr!");
                    return;
                default:
                    Console.WriteLine("\n   Noto'g'ri buyruq! d, m, a yoki e kiriting.\n");
                    break;
            }
        }
    }
}