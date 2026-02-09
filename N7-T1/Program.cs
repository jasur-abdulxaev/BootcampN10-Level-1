TimeOnly workStart = new TimeOnly(9, 00);
TimeOnly workEnd = new TimeOnly(20, 00);

DateTime[] meetings = new DateTime[10]
{
            new DateTime(2026, 2, 2, 8, 30, 0),
            new DateTime(2026, 2, 5, 10, 0, 0),
            new DateTime(2026, 2, 9, 19, 15, 0),
            new DateTime(2026, 2, 11, 16, 30, 0),
            new DateTime(2026, 2, 14, 9, 45, 0),
            new DateTime(2026, 2, 1, 5, 0, 0),
            new DateTime(2026, 2, 22, 13, 30, 0),
            new DateTime(2026, 2, 5, 15, 45, 0),
            new DateTime(2026, 2, 27, 10, 30, 0),
            new DateTime(2026, 2, 28, 22, 0, 0)
};

TimeSpan[] durations = new TimeSpan[10]
{
    TimeSpan.FromMinutes(30),
    TimeSpan.FromMinutes(10),
    TimeSpan.FromMinutes(5),
    TimeSpan.FromMinutes(130),
    TimeSpan.FromMinutes(45),
    TimeSpan.FromMinutes(50),
    TimeSpan.FromMinutes(10),
    TimeSpan.FromMinutes(23),
    TimeSpan.FromMinutes(30),
    TimeSpan.FromMinutes(40),
};

Console.WriteLine("Bad meetings:");
for (int i = 0; i < meetings.Length; i++)
{
    TimeOnly meetingStart = TimeOnly.FromDateTime(meetings[i]);
    TimeOnly meetingEnd = meetingStart.Add(durations[i]);

    if (meetingStart < workStart || meetingEnd > workEnd)
        Console.WriteLine($"{meetings[i]:yyyy-MM-dd HH:mm} | Duration: {durations[i]}");

}

Console.WriteLine("\n30 daqiqadan oshadigan meetinglar:");
for (int i = 0; i < meetings.Length; i++)
{
    if (durations[i].TotalMinutes > 30)
        Console.WriteLine($"{meetings[i]:yyyy-MM-dd} da boshlanuvchi, {durations[i].TotalMinutes} daqiqalik meeting!");
}

TimeSpan totalDuration = TimeSpan.Zero;

for (int i = 0; i < durations.Length; i++)
    totalDuration += durations[i];

Console.WriteLine($"\nTotal meeting duration: {totalDuration.TotalMinutes} minutes" +
    $"Or {Math.Round(totalDuration.TotalHours, 2)} hours");


Array.Sort(meetings, durations);

TimeSpan minGap = TimeSpan.MaxValue;
TimeSpan maxGap = TimeSpan.MinValue;
int minGapIndex = -1;
int maxGapIndex = -1;

for (int i = 0; i < meetings.Length - 1; i++)
{
    DateTime currentEnd = meetings[i] + durations[i];
    DateTime nextStart = meetings[i + 1];

    TimeSpan gap = nextStart - currentEnd;
    if (gap < TimeSpan.Zero)
        gap = TimeSpan.Zero;

    if (gap < minGap)
    {
        minGap = gap;
        minGapIndex = i;
    }

    if (gap > maxGap)
    {
        maxGap = gap;
        maxGapIndex = i;
    }
}

Console.WriteLine($"\nEng kichik bo'sh vaqt: {minGap.TotalMinutes:F2} daqiqa " +
    $"| Meetings: {meetings[minGapIndex]:yyyy-MM-dd HH:mm} -> {meetings[minGapIndex + 1]:yyyy-MM-dd HH:mm}");

Console.WriteLine($"Eng katta bo'sh vaqt: {maxGap.TotalMinutes:F2} daqiqa " +
    $"| Meetings: {meetings[maxGapIndex]:yyyy-MM-dd HH:mm} -> {meetings[maxGapIndex + 1]:yyyy-MM-dd HH:mm}");


