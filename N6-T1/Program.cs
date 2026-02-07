
var date1 = new DateTime(2003, 01, 12);
var date2 = new DateTime(2002, 03, 23);
var date3 = new DateTime(2003, 02, 12);
var date4 = new DateTime(2008, 03, 15);
var date5 = new DateTime(2001, 04, 28);
var date6 = new DateTime(2004, 04, 27);

DateTime[] days = new[] { date1, date2, date3, date4, date5, date6 };
string[] names = new[] { "Azizbek", "Jasur", "Sanjar", "Abdurahmon", "Sulton", "Muzaffar" };

//Sortlash
DateTime today = DateTime.Today;

// Har bir tug'ilgan sanani hozirgi yilga moslab, bugundan keyingi sanani hisoblash
Array.Sort(days, names, Comparer<DateTime>.Create((a, b) =>
{
    // Bu yilga mos sana
    DateTime nextA = new DateTime(today.Year, a.Month, a.Day);
    if (nextA < today) nextA = nextA.AddYears(1); // agar bugundan oldin bo'lsa, keyingi yilga ko'chiramiz

    DateTime nextB = new DateTime(today.Year, b.Month, b.Day);
    if (nextB < today) nextB = nextB.AddYears(1);

    return nextA.CompareTo(nextB); // eng yaqin sana birinchi
}));

// Natijani chiqarish
for (int i = 0; i < days.Length; i++)
{
    Console.WriteLine($"{names[i]} - {days[i].ToShortDateString()}");
}
