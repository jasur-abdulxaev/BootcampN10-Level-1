
// Browser history — LIFO tartibda saqlaydi
var backStack = new Stack<string>();
var forwardStack = new Stack<string>();

// Initial browser history
backStack.Push("https://example.com");
backStack.Push("https://example.com/page1");

// Current site — oxirgi kiritilgan
string currentSite = "https://example.com/page2";

Console.WriteLine($"Hozirgi sahifa: {currentSite}");

while (true)
{
    Console.Write("Buyruqni tanlang (back - b, forward - f, exit - e): ");
    string command = Console.ReadLine().Trim().ToLower();

    if (command == "e")
        break;

    if (command == "b")
    {
        if (backStack.Count == 0)
        {
            Console.WriteLine("Your browser history is empty");
        }
        else
        {
            // Save current site to forward stack
            forwardStack.Push(currentSite);

            // Go back — pop from history
            currentSite = backStack.Pop();
            Console.WriteLine($"Hozirgi sahifa: {currentSite}");
        }
    }
    else if (command == "f")
    {
        if (forwardStack.Count == 0)
        {
            Console.WriteLine("You're currently in this site");
        }
        else
        {
            // Save current site to back stack
            backStack.Push(currentSite);

            // Go forward — pop from forward stack
            currentSite = forwardStack.Pop();
            Console.WriteLine($"Hozirgi sahifa: {currentSite}");
        }
    }
}