// Eventlarni va datalarni alohida alohida arraylarda tuzib olamiz
string[] eventNames = new string[]
{
    "Math Exam",
    "Team Meeting",
    "Doctor Appointment",
    "Project Deadline",
    "Friend Birthday",
    "Online Webinar",
    "Gym Session",
    "Job Interview",
    "Flight to Dubai",
    "Family Dinner"
};

DateTime[] eventDates = new DateTime[]
{
    new DateTime(2026, 1, 25),
    new DateTime(2026, 8, 24),
    new DateTime(2026, 5, 2),
    new DateTime(2026, 2, 5),
    new DateTime(2026, 12, 27),
    new DateTime(2026, 2, 1),
    new DateTime(2026, 4, 5),
    new DateTime(2026, 7, 15),
    new DateTime(2026, 1, 1),
    new DateTime(2026, 9, 19),
};

//Asosiy amallar
while (true)
{
    Console.Clear();
    ShowMenu();
    int choise = GetUserChoise(1, 8);

    switch (choise)
    {
        case 1: SortEvents(); break;
        case 2: FindEventByName(); break;
        case 3: FindEventByTime(); break;
        case 4: ShowUpcomingEvents(); break;
        case 5: ShowPassedEvents(); break;
        case 6: ShowUpcomingByCloseness(); break;
        case 7: ShowPassedByCloseness(); break;
        case 8: return;
    }

    Console.WriteLine("\nDavom etish uchun biror tugmani bosing...");
    Console.ReadKey(); // foydalanuvchi natijani ko'rib keyingi menu uchun tugmani bosadi
}

static void ShowMenu()
{
    Console.WriteLine("\nQuyidagilardan bittasini tanlang:");
    Console.WriteLine("1. Eventlarni saralash");
    Console.WriteLine("2. Eventni nomi bo'yicha topish");
    Console.WriteLine("3. Eventni vaqti bo'yicha topish");
    Console.WriteLine("4. Kelayotgan eventlarni ko'rsatish");
    Console.WriteLine("5. O'tib ketgan eventlarni ko'rsatish");
    Console.WriteLine("6. Kelayotgan eventlarni yaqinligi bo'yicha");
    Console.WriteLine("7. O'tib ketgan eventlarni yaqinligi bo'yicha");
    Console.WriteLine("8. Dasturni yopish");
    Console.Write("Tanlovingiz: ");
}

static int GetUserChoise(int min, int max)
{
    while (true)
    {
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Hech narsa kritilmadi qaytadan urinib ko'ring!");
            continue;
        }

        bool isNumber = int.TryParse(input, out int choise);
        if (!isNumber)
        {
            Console.WriteLine("Faqat raqam kiriting!");
            continue;
        }

        if (choise < min || choise > max)
        {
            Console.WriteLine($"Iltimos, {min} dan {max} gacha raqam kiriting!");
            continue;
        }

        return choise;
    }
}

void SortEvents()
{
    Console.WriteLine("Saralash turini tanlang:");
    Console.WriteLine("1. Event nomi bo'yicha");
    Console.WriteLine("2. Event vaqti bo'yicha");
    int type = GetUserChoise(1, 2);

    Console.WriteLine("Qaysi tartibda ekranga chiqsin: 1 - O'sish, 2 - Kamayish");
    int order = GetUserChoise(1, 2);
    bool ascending = order == 1;

    if (type == 1)
    {
        // Nom bo'yicha sort
        Array.Sort(eventNames, eventDates, StringComparer.OrdinalIgnoreCase);
        if (!ascending)
        {
            Array.Reverse(eventNames);
            Array.Reverse(eventDates);
        }
    }
    else
    {
        // Vaqt bo'yicha sort
        Array.Sort(eventDates, eventNames);
        if (!ascending) Array.Reverse(eventDates); Array.Reverse(eventNames);
    }

    Console.WriteLine("Saralangan eventlar: ");
    for (int i = 0; i < eventNames.Length; i++)
    {
        Console.WriteLine($"{eventNames[i]} - {eventDates[i].ToString("yyyy-MM-dd")}");
    }
}

void FindEventByName()
{
    Console.Write("Qidirilayotgan event nomini kiriting: ");
    string name = Console.ReadLine();

    bool found = false;
    for (int i = 0; i < eventNames.Length; i++)
    {
        if (eventNames[i].IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            Console.WriteLine($"{eventNames[i]} - {eventDates[i]:yyyy-MM-dd}");
            found = true;
        }
    }
    if (!found) Console.WriteLine("Event topilmadi!");
}

void FindEventByTime()
{
    Console.WriteLine("Qidiriladigan sanani kiriting (yyy-MM-dd): ");
    string input = Console.ReadLine();

    if (!DateTime.TryParse(input, out DateTime date))
    {
        Console.WriteLine("Noto'g'ri format!");
        return;
    }

    bool found = false;
    for (int i = 0; i < eventDates.Length; i++)
    {
        if (eventDates[i].Date == date.Date)
        {
            Console.WriteLine($"{eventNames[i]} - {eventDates[i]:yyyy-MM-dd}");
            found = true;
        }
    }

    if (!found) Console.WriteLine("Event topilmadi!");
}


void ShowUpcomingEvents()
{
    DateTime now = DateTime.Now;
    bool found = false;
    for (int i = 0; i < eventDates.Length; i++)
    {
        if (eventDates[i] > now)
        {
            Console.WriteLine($"{eventNames[i]} - {eventDates[i]:yyyy-MM-dd}");
            found = true;
        }
    }
    if (!found) Console.WriteLine("Kelayotgan eventlar yoq!");
}

void ShowPassedEvents()
{
    DateTime now = DateTime.Now;
    bool found = false;
    for (int i = 0; i < eventDates.Length; i++)
    {
        if (eventDates[i] < now)
        {
            Console.WriteLine($"{eventNames[i]} - {eventDates[i]:yyy-MM-dd}");
            found = true;
        }
    }
    if (!found) Console.WriteLine("O'tib ketgan eventlar yo'q");
}

void ShowUpcomingByCloseness()
{
    DateTime now = DateTime.Now;
    var upcoming = new System.Collections.Generic.List<(string name, DateTime date)>();
    for (int i = 0; i < eventDates.Length; i++)
    {
        if (eventDates[i] > now)
        {
            upcoming.Add((eventNames[i], eventDates[i]));
        }
    }

    upcoming.Sort((a, b) => a.date.CompareTo(b.date));

    if (upcoming.Count == 0)
        Console.WriteLine("Kelayotgan eventlar yo'q");
    else
        foreach (var e in upcoming)
            Console.WriteLine($"{e.name} - {e.date:yyyy-MM-dd}");
}

void ShowPassedByCloseness()
{
    DateTime now = DateTime.Now;
    var passed = new System.Collections.Generic.List<(string name, DateTime date)>();
    for (int i = 0; i < eventDates.Length; i++)
    {
        if (eventDates[i] < now)
            passed.Add((eventNames[i], eventDates[i]));
    }

    passed.Sort((a, b) => b.date.CompareTo(a.date));

    if (passed.Count == 0)
    {
        Console.WriteLine("O'tib ketgan eventlar yo'q");
    }
    else
        foreach (var e in passed)
            Console.WriteLine($"{e.name} - {e.date:yyyy-MM-dd}");
}
