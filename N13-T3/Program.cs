

public class Event
{
    public string Name { get; }

    public Event(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public override string ToString() => Name;
}

public class DailyEvent : Event
{
    public TimeOnly Time { get; }

    public DailyEvent(string name, TimeOnly time) : base(name)
    {
        Time = time;
    }

    public override string ToString() => $"{Name} - Har kuni {Time:HH:mm}";
}

public class ScheduleEvent : Event
{
    public DateTime Date { get; }
    public ScheduleEvent(string name, DateTime date) : base(name)
    {
        Date = date;
    }
    public override string ToString() => $"{Name} - {Date:yyyy-MM-dd}";
}

public class EventManager
{
    private readonly List<DailyEvent> _events = new List<DailyEvent>();
    private readonly List<ScheduleEvent> _scheduleEvents = new List<ScheduleEvent>();

    public void Add(string name, TimeOnly time)
    {
        _events.Add(new DailyEvent(name, time));
    }

    public void Add(string name, DateTime date)
    {
        _scheduleEvents.Add(new ScheduleEvent(name, date));
    }

    public void DisplayEvents()
    {

        var today = DateTime.Today;
        var upcomingEvents = _scheduleEvents
            .Where(e => e.Date.Date >= today && e.Date.Date <= today.AddDays(3))
            .OrderBy(e => e.Date);

        Console.WriteLine("=== Har kunlik eventlar ===");
        foreach (var ev in _events)
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

        manager.Add("Saharlik", new TimeOnly(6, 0));
        manager.Add("Ishga borish", new TimeOnly(8, 0));

        manager.Add("Tug'ilgan kun", DateTime.Today);
        manager.Add("Konferensiya", DateTime.Today.AddDays(2));
        manager.Add("Yillik yig'ilish", DateTime.Today.AddDays(5));

        manager.DisplayEvents();
    }
}
