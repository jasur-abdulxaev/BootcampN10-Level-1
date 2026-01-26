Console.Write("Enter your first name: ");
var firstName = Console.ReadLine();

Console.Write("Enter your last name: ");
var  lastName = Console.ReadLine();

Console.Write("Enter your age: ");
var age = Convert.ToInt32(Console.ReadLine());

var fullInfo = firstName + " " + lastName + " " + age + "yosh.";

Console.Write("12 * 3 = ");
var result = Convert.ToInt32(Console.ReadLine());

if (result == 36)
    Console.WriteLine(fullInfo);
else
    Console.WriteLine("You are not human");
