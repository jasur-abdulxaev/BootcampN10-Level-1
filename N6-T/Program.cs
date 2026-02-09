var random = new Random();
var uniqueValues = new List<int>();

for (int indexA = 0; indexA < 250_000_000;)
{
    var randomValue = random.Next(1, 1_000_000_000);

    if (uniqueValues.Count == 0)
        uniqueValues.Add(randomValue);

    for (int indexB = 0; indexB < uniqueValues.Count; indexB++)
    {
        if (uniqueValues[indexB] == randomValue)
        {
            Console.WriteLine($"Duplicate value generating unique value - {randomValue}");
            Console.WriteLine(uniqueValues.Capacity);
            Console.WriteLine(uniqueValues.Count);
            break;
        }
        else
        {
            uniqueValues.Add(randomValue);
            indexA++;
            break;
        }
    }
}

Console.ReadLine();
