using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;
using N31_Amaliyot.Models;

// 1. Fayl yo'llarini sozlash
string baseDir = @"D:\Projects\Repositories\NajotTalim\BootcampN10-Level-1\BootcampN10-Level-1\N31-Amaliyot\DataLayer";
string studentPath = Path.Combine(baseDir, "Student.json");
string locationPath = Path.Combine(baseDir, "Location.json");
string specialityPath = Path.Combine(baseDir, "Speciality.json");

// 2. Ma'lumotlarni o'qish (UTF-8 kodlash bilan)
var students = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(studentPath, Encoding.UTF8)) ?? new();
var locations = JsonSerializer.Deserialize<List<Location>>(File.ReadAllText(locationPath, Encoding.UTF8)) ?? new();
var specialities = JsonSerializer.Deserialize<List<Speciality>>(File.ReadAllText(specialityPath, Encoding.UTF8)) ?? new();

// --- Task 1: Mutaxassislik bo'yicha talabalar soni ---
var studentsCountBySpeciality = specialities.GroupJoin(
    students,
    spec => spec.id,
    stud => stud.speciality_id,
    (spec, studGroup) => new
    {
        SpecialityName = spec.speciality_name,
        TotalStudents = studGroup.Count()
    }
);

// --- Task 2: Hududlar bo'yicha o'rtacha yosh ---
var avgAgeByLocation = locations.GroupJoin(
    students,
    loc => loc.id,
    stud => stud.location_id,
    (loc, studGroup) => new
    {
        LocationName = loc.lacation_name,
        AverageAge = studGroup.Any()
            ? Math.Round(studGroup.Average(s => CalculateAge(s.birth_day)), 1)
            : 0
    }
);

// --- Task 3: To'liq birlashtirilgan hisobot ---
var fullReport = from stud in students
                 join spec in specialities on stud.speciality_id equals spec.id
                 join loc in locations on stud.location_id equals loc.id
                 select new
                 {
                     FullName = $"{stud.first_name} {stud.last_name}",
                     Speciality = spec.speciality_name,
                     Location = loc.lacation_name,
                     Age = CalculateAge(stud.birth_day)
                 };

// 3. Natijalarni chiroyli va o'zbekcha harflarni saqlagan holda chiqarish
var jsonOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    // G', O' kabi harflar buzilmasligi uchun:
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

Console.WriteLine("--- 1-VAZIFA: MUTAXASSISLIKLAR BO'YICHA STATISTIKA ---");
Console.WriteLine(JsonSerializer.Serialize(studentsCountBySpeciality, jsonOptions));

Console.WriteLine("\n--- 2-VAZIFA: HUDUDLAR BO'YICHA O'RTACHA YOSH ---");
Console.WriteLine(JsonSerializer.Serialize(avgAgeByLocation, jsonOptions));

Console.WriteLine("\n--- 3-VAZIFA: TALABALAR HAQIDA TO'LIQ MA'LUMOT ---");
Console.WriteLine(JsonSerializer.Serialize(fullReport, jsonOptions));

// --- YORDAMCHI METODLAR ---
static int CalculateAge(string birthDayStr)
{
    if (string.IsNullOrWhiteSpace(birthDayStr)) return 0;

    // "8/8/2004" yoki "25/09/2001" kabi turli formatlarni qo'llab-quvvatlaydi
    string[] formats = { "d/M/yyyy", "dd/MM/yyyy", "d.M.yyyy", "dd.MM.yyyy", "yyyy-MM-dd" };

    if (DateTime.TryParseExact(birthDayStr, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var birthDate))
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;

        // Agar bu yilgi tug'ilgan kuni hali kelmagan bo'lsa
        if (birthDate.Date > today.AddYears(-age)) age--;

        return age;
    }

    return 0; // Sana o'qilmasa 0 qaytaradi
}