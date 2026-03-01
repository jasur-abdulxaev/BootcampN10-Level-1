public class Car
{
    public string Name { get; set; }
    public string Brand { get; set; }

    public Car(string name, string brand)
    {
        Name = name;
        Brand = brand;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Car other)
            return Name == other.Name && Brand == other.Brand;
        return false;
    }

    public override int GetHashCode() => HashCode.Combine(Name, Brand);

    public override string ToString() => $"{Name} - {Brand}";
}

class Program
{
    static void Main()
    {
        List<Car> cars = new List<Car>
        {
            new Car("Accord", "Honda"),
            new Car("Camry", "Toyota"),
            new Car("Civic", "Honda"),
            new Car("Accord", "Honda"),
            new Car("Elantra", "Hyundai"),
            new Car("Accord", "Honda"),
            new Car("Sonata", "Hyundai"),
            new Car("Elantra", "Hyundai"),
            new Car("Fusion", "Ford"),
            new Car("Malibu", "Chevrolet")
        };

        var duplicates = cars
            .GroupBy(x => x)
            .Where(g => g.Count() > 1);

        foreach (var group in duplicates)
        {
            Console.WriteLine($"{group.Key} - {group.Count()}");
        }
    }
}


