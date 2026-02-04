Console.WriteLine("Simple Calculator\n");

while (true)
{
    int firstNumber = ReadInt("Enter first number: ");
    int secondNumber = ReadInt("Enter second number: ");

    string operation = ReadOperation("Choose operation (+, -, *, /): ");

    double result = Calculate(firstNumber, secondNumber, operation);

    Console.WriteLine(result);

    Console.Write("Do you want to calculate again? (y/n): ");
    string again = Console.ReadLine().ToLower();
    if (again != "y")
        break;
}
Console.WriteLine("Goodbye!");

// Foydalanuvchidan son olish operatsiyasi
static int ReadInt(string message)
{
    int result;
    while (true)
    {
        Console.Write(message);
        string input = Console.ReadLine();

        if (int.TryParse(input, out result))
        {
            return result;
        }
        else
        {
            Console.WriteLine("This is not number! ");
        }
    }
}

// Foydalanuvchidan amalni tanlash operatsiyasi
static string ReadOperation(string message)
{
    while (true)
    {
        Console.Write(message);
        string op = Console.ReadLine();

        if (op == "+" || op == "-" || op == "*" || op == "/")
        {
            return op;
        }
        else
        {
            Console.WriteLine("Invalid operation. Please enter +, -, * or /.");
        }
    }
}

// Hisoblash funksiyasi
static double Calculate(int a, int b, string op)
{
    switch (op)
    {
        case "+":
            return a + b;
        case "-":
            return a - b;
        case "*":
            return a * b;
        case "/":
            if (b == 0)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                return double.NaN;
            }
            return (double)a / b;
        default:
            return double.NaN;
    }
}