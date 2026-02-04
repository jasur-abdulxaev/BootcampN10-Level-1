using System;

var questions = new (string Question, string Correct, string Wrong)[]
{
    ("\"string\" tipidagi o'zgaruvchilar qayerda saqlanadi?", "Heap xotirada", "Stack da"),
    ("string taqqoslashda '==' nima bo'yicha ishlaydi?", "Value", "Reference"),
    ("object class memberlariga bevosita access beradimi?", "Yo'q", "Ha"),
    ("C# dasturlash tili qachon yaratilgan?", "2002-yil", "2000-yil"),
    ("C# dasturlash tilining asoschisi kim?", "Anders Hejlsberg", "John Doe")
};

var rand = new Random();
int score = 0;
string mistakes = "";

for (int i = 0; i < questions.Length; i++)
{
    Console.Clear();

    var q = questions[i];
    bool isCorrectA = rand.Next(2) == 0;

    Console.WriteLine(q.Question);

    if (isCorrectA)
    {
        Console.WriteLine($"A) {q.Correct}");
        Console.WriteLine($"B) {q.Wrong}");
    }
    else
    {
        Console.WriteLine($"A) {q.Wrong}");
        Console.WriteLine($"B) {q.Correct}");
    }

    Console.Write("Javobingiz (A/B): ");
    var input = Console.ReadLine();

    if (input == null ||
        !(input.Equals("A", StringComparison.OrdinalIgnoreCase) ||
          input.Equals("B", StringComparison.OrdinalIgnoreCase)))
    {
        Console.WriteLine("Noto'g'ri variant. Qaytadan urinib ko'ring.");
        i--;
        Thread.Sleep(1000);
        continue;
    }

    bool userCorrect =
        (input.Equals("A", StringComparison.OrdinalIgnoreCase) && isCorrectA) ||
        (input.Equals("B", StringComparison.OrdinalIgnoreCase) && !isCorrectA);

    if (userCorrect)
    {
        score++;
    }
    else
    {
        mistakes += $"Savol: {q.Question}\nTo'g'ri javob: {q.Correct}\n\n";
    }
}

Console.Clear();
Console.WriteLine($"Ball: {score} / {questions.Length}");

if (mistakes.Length == 0)
{
    Console.WriteLine("Barcha javoblar to'g'ri. Juda yaxshi.");
}
else
{
    Console.WriteLine("Xatolar:");
    Console.WriteLine(mistakes);
}
