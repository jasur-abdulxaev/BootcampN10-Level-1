Console.Write("Yoshingizni kiriting: ");
int age = int.Parse(Console.ReadLine()!);

try
{
    string message = CheckAge(age);
    Console.WriteLine(message);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.Message);
}

static string CheckAge(int age)
{
    return age switch
    {
        < 18 => throw new ArgumentOutOfRangeException(nameof(age), "Sorry, you're too young"),
        > 90 => throw new ArgumentOutOfRangeException(nameof(age), "Sorry, you're too old"),
        _ => "Valid age"
    };
}