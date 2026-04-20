using N39_HT1.Models;

var userAndWeather = new List<object>
{
    new User("John", "Doe"),
    new WeatherReport("Sunny", 25.0),
    new User("Jane", "Smith"),
    new WeatherReport("Rainy", 18.5),
    new User("Alice", "Johnson"),
    new WeatherReport("Cloudy", 20.0)
};

foreach (var obj in userAndWeather)
{
    if (obj is User user && user is { FirstName: "Jane", LastName: "Smith" })
    {
        Console.WriteLine($"User: {user}");
    }
    else if (obj is WeatherReport weatherReport && weatherReport is { State: "Sunny", Degree: 25.0 })
    {
        Console.WriteLine($"Weather Report: {weatherReport}");
    }
}