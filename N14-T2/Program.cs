

namespace EventPlannerSystem
{
    // Daily event structure
    public class DailyEvent
    {
        public string Name { get; set; }
        public int Hour { get; set; }

        public DailyEvent(string name, int hour)
        {
            Name = name;
            Hour = hour;
        }

        public override string ToString()
        {
            return $"{Hour}:00 - {Name}";
        }
    }

    // Calendar eventstructure
    public class CalendarEvent
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public CalendarEvent(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }
        public override string ToString()
        {
            return $"  [{Date:yyyy-MM-dd}] {Name}";
        }
    }

    // Base planner service
    public class Planner
    {
        protected List<DailyEvent> dailyEvents = new List<DailyEvent>();

        public Planner()
        {
            dailyEvents = new List<DailyEvent>();
        }

        // Add a daily event to collectiom
        public virtual void Add(string eventName, int hour)
        {
            var dailyEvent = new DailyEvent(eventName, hour);
            dailyEvents.Add(dailyEvent);
            Console.WriteLine($"Added daily event: {eventName} at {hour}:00");
        }

        // Display all daily events
        public virtual void Display()
        {
            Console.WriteLine("Daily Events:");
            if (dailyEvents.Count == 0)
            {
                Console.WriteLine(" No daily events scheduled");
            }
            else
            {
                // Sort events by hour before displaying
                var sortedEvents = dailyEvents.OrderBy(e => e.Hour).ToList();
                foreach (var dailyEvent in sortedEvents)
                {
                    Console.WriteLine(dailyEvent);
                }
            }
        }
    }

    // Ultimate planner service with calendar support and conflicts detection
    public class UltimatePlanner : Planner
    {
        private List<CalendarEvent> calendarEvents = new List<CalendarEvent>();

        public UltimatePlanner() : base()
        {
            calendarEvents = new List<CalendarEvent>();
        }

        // Override Parent's Add method with conflict detection
        public override void Add(string eventName, int hour)
        {
            // Check if there's already an event at this hour
            var existingEvent = dailyEvents.FirstOrDefault(e => e.Hour == hour);

            if (existingEvent != null)
            {
                Console.WriteLine($"\n*** You have conflict in daily plan ***");
                Console.WriteLine($"Conflict: '{existingEvent.Name}' and '{eventName}' both scheduled at {hour}:00");
                Console.WriteLine("Event still added, but please resolve the conflict.\n");
            }

            // Call base class method to add the event
            base.Add(eventName, hour);
        }

        // Overload Add method for calendar events
        public void Add(string eventName, DateTime date)
        {
            var calendarEvent = new CalendarEvent(eventName, date);
            calendarEvents.Add(calendarEvent);
            Console.WriteLine($"Added calendar event: {eventName} on {date:yyyy-MM-dd}");
        }

        // Override Display to show calendar events first, then daily events
        public override void Display()
        {
            Console.WriteLine("ULTIMATE PLANNER - ALL EVENTS\n");

            // Display calendar events first
            Console.WriteLine("Calendar Events:");
            if (calendarEvents.Count == 0)
            {
                Console.WriteLine(" No calendar events scheduled");
            }
            else
            {
                // Sort calendar events by date before displaying
                var sortedCalendarEvents = calendarEvents.OrderBy(e => e.Date).ToList();
                foreach (var calendarEvent in sortedCalendarEvents)
                {
                    Console.WriteLine(calendarEvent);
                }
            }

            // Then display daily events using base class logic
            base.Display();

            Console.WriteLine("=================================================================\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EVENT PLANNER SYSTEM DEMONSTRATION \n");

            // Part 1: Using base Planner
            Console.WriteLine("PART 1: Basic Planner Service\n");

            Planner basicPlanner = new Planner();
            basicPlanner.Add("Morning Meeting", 9);
            basicPlanner.Add("Lunch Break", 12);
            basicPlanner.Add("Lunch Break", 13);
            basicPlanner.Display();

            // Part 2: Using UltimatePlanner with conflict detection
            Console.WriteLine("PART 2: Ultimate Planner Service");

            UltimatePlanner ultimatePlanner = new UltimatePlanner();

            // Adding 3 daily events (2 at the same hour - conflict)
            Console.WriteLine("--- Adding Daily Events ---");
            ultimatePlanner.Add("Morning Meeting", 9);
            ultimatePlanner.Add("Team Sync", 9); // Conflict with Morning Meeting
            ultimatePlanner.Add("Lunch Break", 12);

            // Adding 3 calendar events
            Console.WriteLine("\n--- Adding Calendar Events ---");
            ultimatePlanner.Add("Project Deadline", new DateTime(2024, 7, 15));
            ultimatePlanner.Add("Client Presentation", new DateTime(2024, 7, 20));
            ultimatePlanner.Add("Company Retreat", new DateTime(2024, 8, 5));

            // Display all events in UltimatePlanner
            Console.WriteLine("\n--- Displaying Ultimate Planner ---");
            ultimatePlanner.Display();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}