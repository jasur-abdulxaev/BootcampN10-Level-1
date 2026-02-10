

var date = new DateOnly(2026, 02, 10);
var days = new DateOnly[]
{
    date.AddDays(0),
    date.AddDays(-1),
    date.AddDays(-2),
    date.AddDays(-3),
    date.AddDays(-4),
};

var durations = new[]
{
    TimeSpan.FromHours(8),
    TimeSpan.FromHours(7),
    TimeSpan.FromHours(6),
    TimeSpan.FromHours(5),
    TimeSpan.FromHours(10),
};

var divisions = new[] { 1, 0, 0, 2, 1 };

double previousMissing = 0;

for (int i = 0; i < days.Length; i++)
{
    double awakeningIndex = CalculateAwakeningIndex(divisions[i], durations[i]);
    double score = CalculateSleepQualityScore(durations[i], awakeningIndex, previousMissing);

    // Ekstra: keyingi kun uchun previousMissing yangilanadi
    previousMissing = CalculatePreviousDayMissingSleep(durations[i]);

    // Natijani ekranga chiqarish
    Console.WriteLine($"{days[i]:dd.MM.yyyy} - {durations[i].TotalHours} hours - {score:F2} score");
}

double CalculateAwakeningIndex(int divisions, TimeSpan duration)
{
    //Duration 0 bo'lmasligi uchun
    if (duration.TotalHours <= 0)
        return 0;

    return (double)divisions / duration.TotalHours;
}

double CalculatePreviousDayMissingSleep(TimeSpan previousDayDuration)
{
    double missing = 8 - previousDayDuration.TotalHours;
    return missing > 0 ? missing : 0;
}

double CalculateSleepQualityScore(TimeSpan duration, double awakeningIndex, double previousMissingSleep)
{
    double score = (duration.TotalHours - awakeningIndex) / (8 + previousMissingSleep) * 10;
    return score;
}