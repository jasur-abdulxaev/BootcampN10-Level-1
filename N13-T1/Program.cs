public class Hero
{
    public int Id { get; }
    public string Name { get; }

    public Hero(int id, string name)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public override string ToString() => $"[{Id}] {Name}";
}

public class GameEngine
{
    protected readonly List<Hero> Heroes = new List<Hero>();

    public GameEngine()
    {
        Heroes.Add(new Hero(1, "Yurnero"));
        Heroes.Add(new Hero(2, "Sven"));
        Heroes.Add(new Hero(3, "Tiny"));
    }

    public void Display()
    {
        foreach (var hero in Heroes)
            Console.WriteLine(hero);
    }
}

public class OptimizedGameEngine : GameEngine
{
    public OptimizedGameEngine()
    {
        Heroes.Add(new Hero(4, "Invoker"));
        Heroes.Add(new Hero(5, "Lina"));
        Heroes.Add(new Hero(6, "Medusa"));
    }
}

class Program
{
    static void Main()
    {
        var engine = new OptimizedGameEngine();
        engine.Display();
    }
}