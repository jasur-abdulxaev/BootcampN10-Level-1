#region  Pattern matching

Console.WriteLine("Pattern matching");

var value = (object)"false";

Console.WriteLine(value.GetType);

//Declarative Type Pattern matching - is, as
Console.WriteLine("Declarative Pattern matching :  ");

// Check and conversion in one
if (value is int resultIntValue)
{
    Console.WriteLine(resultIntValue);
}
else if (value is string stringValue)
{
    Console.WriteLine(stringValue);
}
Console.WriteLine();


//Relational Pattern matching
Console.WriteLine("Relational Pattern matching");

var grade = 80;
var gradeLevel = grade switch
{
    >= 90 => "Top",
    >= 80 and < 90 => "Good",
    >= 70 and < 80 => "Normal",
    _ => "Bad"
};
Console.WriteLine(gradeLevel);
Console.WriteLine();

#endregion

