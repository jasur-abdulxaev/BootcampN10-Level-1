

public class Event
{
    public string Name { get; }
    public DateTime? Date { get; }
    public TimeOnly? DailyTime { get; }

    public Event(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }

    public Event(string name, TimeOnly dailyTime)
    {
        Name = name;
        DailyTime = dailyTime;
    }

    public override string ToString()
    {
        return DailyTime.HasValue
            ? $"{Name} - Har kuni {DailyTime:HH:mm}"
            : $"{Name} - {Date:yyyy-MM-dd}";
    }
}

public class EventManager
{
    private readonly List<Event> _events = new List<Event>();
    public void Add(string name, DateTime date)
    {
        _events.Add(new Event(name, date));
    }

    public void Add(string name, TimeOnly dailyTime)
    {
        _events.Add(new Event(name, dailyTime));
    }

    public void DisplayEvents()
    {
        var dailyEvents = _events.Where(e => e.DailyTime.HasValue);
        var upcomingEvents = _events
            .Where(e => e.Date.HasValue && e.Date.Value.Date >= DateTime.Today
            && e.Date.Value.Date <= DateTime.Today.AddDays(3))
            .OrderBy(e => e.Date);

        Console.WriteLine("=== Har kunlik eventlar ===");
        foreach (var ev in dailyEvents)
            Console.WriteLine(ev);

        Console.WriteLine("\n=== Keyingi 3 kundagi eventlar ===");
        foreach (var ev in upcomingEvents)
            Console.WriteLine(ev);
    }
}

class Program
{
    static void Main()
    {
        var manager = new EventManager();

        manager.Add("Ertalabki mashq", new TimeOnly(7, 0));
        manager.Add("Tushlik", new TimeOnly(13, 0));

        manager.Add("Jamoa yig'ilishi", DateTime.Today);
        manager.Add("Deadline", DateTime.Today.AddDays(2));
        manager.Add("Konferensiya", DateTime.Today.AddDays(5)); // ko'rinmaydi

        manager.DisplayEvents();
    }
}
