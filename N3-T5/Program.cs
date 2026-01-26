Console.Write("Enter some text: ");
var text = Console.ReadLine();

Console.Write("Index: ");
var index = Convert.ToInt32(Console.ReadLine());

Console.Write("Uzunlik: ");
var length = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Your text: {text}\nFirstlatter: {text[0]}\nText Length: {text.Length}\nSubstring text: {text.Substring(index, length)}");
