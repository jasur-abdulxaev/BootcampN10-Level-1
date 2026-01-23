//HT-1
Console.WriteLine("Home Tasks - 1");
Console.Write("Enter your first name: ");
string firstName = Console.ReadLine();

Console.Write("Last name: ");
string lastName = Console.ReadLine();

Console.Write("Enter your age: ");
byte age = byte.Parse(Console.ReadLine());

Console.WriteLine($"\nFirst name: {firstName}\nLast name: {lastName}\nAge: {age}\n");

//HT-2
Console.WriteLine("Task - 2");
DateTime today = DateTime.Now;
var date = DateTime.UnixEpoch;
byte ageX = 32;
float balance = 35.5F;
string name = "Max developer";

Console.WriteLine(today);
Console.WriteLine(date.ToString("yyyy dd MMMM"));
Console.WriteLine(ageX);
Console.WriteLine(balance);
Console.WriteLine(name);

// HT-3
Console.WriteLine("\nTask - 3");
//Primitive
bool isAlive = false;
int price = 184_000;

Console.WriteLine($"Primitive types: {isAlive}, {price}");

//Complex
DateTime now = DateTime.Now;

Console.WriteLine($"Copmlex type {now}");

//Value type
char letter = 'A';
int population = 37_225_000;

Console.WriteLine($"Value types: {letter}, {population}");

//Reference types
string modelName = "HP Victus";

Console.WriteLine($"Reference types: {modelName}");
