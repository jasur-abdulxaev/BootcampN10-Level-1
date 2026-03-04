Console.OutputEncoding = System.Text.Encoding.UTF8;

var quiz = new LinkedList<KeyValuePair<string, string>>();

quiz.AddLast(new KeyValuePair<string, string>("What is the capital city of Australia?", "Canberra"));
quiz.AddLast(new KeyValuePair<string, string>("Which river is the longest in South America?", "Amazon"));
quiz.AddLast(new KeyValuePair<string, string>("Name the largest island in the world", "Greenland"));
quiz.AddLast(new KeyValuePair<string, string>("What is the smallest country in the world?", "Vatican"));
quiz.AddLast(new KeyValuePair<string, string>("Which planet is known as the Red Planet?", "Mars"));

int correct = 0;
var current = quiz.First;

while (current != null)
{
    Console.WriteLine(current.Value.Key);
    Console.Write("Javob: ");
    string answer = Console.ReadLine().Trim();

    if (string.Equals(answer, current.Value.Value, StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("✅ To'g'ri!\n");
        correct++;
    }
    else
    {
        Console.WriteLine($"❌ Noto'g'ri! Javob: {current.Value.Value}\n");
    }

    current = current.Next;
}
Console.WriteLine($"Natija: {correct}/{quiz.Count}");

