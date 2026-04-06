//  Setup

var userCredentialsService = new UserCredentialsService();
var userService = new UserService();
var registrationService = new RegistrationService(userService, userCredentialsService);

Console.OutputEncoding = System.Text.Encoding.UTF8;

//  1. Register bir nechta userlar

var registrations = new[]
{
    ("Azizbek",   "Abdurahmonov", "abdura52.uz@gmail.com",    "qwery1234"),
    ("Virginia",  "Cox",          "virginia@gmail.com",       "password123456"),
    ("Carolyn",   "Ward",         "carolyn@gmail.com",        "qwerty123456"),
    ("Catherine", "Hayes",        "catherine@gmail.com",      "securepass123456"),
    ("Shirley",   "Hamilton",     "shirley@gmail.com",        "testpass123456"),
    ("Gloria",    "Sanders",      "gloria@gmail.com",         "ilovecoding123456"),
    ("Danielle",  "Gonzalez",     "danielle@gmail.com",       "changeme123456"),
    ("Christina", "Reyes",        "christina@gmail.com",      "mypassword123456"),
    ("Debra",     "Foster",       "debra@gmail.com",          "welcome123456"),
    ("Janice",    "Brooks",       "janice@gmail.com",         "randompass123456"),
    ("Kelly",     "Jenkins",      "kelly@gmail.com",          "secure123456"),
    ("Martha",    "Ward",         "martha@gmail.com",         "123456pass"),
    ("Andrea",    "Bryant",       "andrea@gmail.com",         "pass123456"),
    ("Frances",   "Perez",        "frances@gmail.com",        "123456test"),
    ("Joyce",     "Coleman",      "joyce@gmail.com",          "123456secure"),
    ("Mary",      "Nichols",      "mary@gmail.com",           "123456password"),
    ("Theresa",   "Johnson",      "theresa@gmail.com",        "123456random"),
    ("Rita",      "Patterson",    "rita@gmail.com",           "123456welcome"),
    ("Rose",      "Hernandez",    "rose@gmail.com",           "123456ilovecoding"),
    ("Emma",      "Ramirez",      "emma@gmail.com",           "123456changeme"),
    ("Alice",     "Butler",       "alice@gmail.com",          "123456mypassword"),
    ("Julie",     "Simmons",      "julie@gmail.com",          "12345678pass"),
    ("Evelyn",    "Barnes",       "evelyn@gmail.com",         "12345678test"),
    ("Kim",       "Fisher",       "kim@gmail.com",            "12345678secure"),
    ("Maria",     "Cole",         "maria@gmail.com",          "12345678password"),
    ("Heather",   "Mitchell",     "heather@gmail.com",        "12345678random"),
    ("Diane",     "Ortiz",        "diane@gmail.com",          "12345678welcome"),
    ("Alice",     "Gomez",        "alice2@gmail.com",         "12345678ilovecoding"),
    ("Julia",     "Murray",       "julia@gmail.com",          "12345678changeme"),
    ("Grace",     "Ford",         "grace@gmail.com",          "12345678mypassword"),
    ("Victoria",  "Patterson",    "victoria@gmail.com",       "12345678qwerty"),
    ("Christine", "Howell",       "christine2@gmail.com",     "12345678abc123"),
    ("Deborah",   "Gonzalez",     "deborah2@gmail.com",       "12345678xyz987"),
    ("Teresa",    "White",        "teresa2@gmail.com",        "12345678letmein"),
    ("Janet",     "Hughes",       "janet2@gmail.com",         "12345678pass123"),
    ("Denise",    "King",         "denise2@gmail.com",        "12345678test123"),
    ("Rebecca",   "Brooks",       "rebecca2@gmail.com",       "12345678secure123"),
    ("Catherine", "Baker",        "catherine2@gmail.com",     "12345678password123"),
    ("Stephanie", "Hall",         "stephanie2@gmail.com",     "12345678random123"),
    ("Kelly",     "Adams",        "kelly2@gmail.com",         "12345678welcome123"),
    ("Megan",     "Russell",      "megan2@gmail.com",         "12345678ilovecoding123"),
    ("Lisa",      "Harris",       "lisa@gmail.com",           "securepassword"),
    ("Betty",     "Young",        "betty@gmail.com",          "pass1234"),
    ("Dorothy",   "Allen",        "dorothy@gmail.com",        "userpass"),
    ("Sandra",    "King",         "sandra@gmail.com",         "randompass123"),
    ("Ashley",    "Wright",       "ashley@gmail.com",         "welcome1234"),
    ("Kimberly",  "Lopez",        "kimberly@gmail.com",       "testpass"),
    ("Donna",     "Scott",        "donna@gmail.com",          "newpass"),
    ("Emily",     "Green",        "emily@gmail.com",          "password1234"),
    ("Michelle",  "Adams",        "michelle@gmail.com",       "securepass123"),
    ("Carol",     "Baker",        "carol@gmail.com",          "passw0rd123"),
    ("Amanda",    "Gonzalez",     "amanda@gmail.com",         "mypassword"),
    ("Melissa",   "Nelson",       "melissa@gmail.com",        "abc123"),
    ("Deborah",   "Carter",       "deborah@gmail.com",        "testpass1234"),
    ("Stephanie", "Hill",         "stephanie@gmail.com",      "letmein1234"),
    ("Rebecca",   "Perez",        "rebecca@gmail.com",        "changeme123"),
    ("Laura",     "Roberts",      "laura@gmail.com",          "ilovecoding123"),
    ("Sharon",    "Turner",       "sharon@gmail.com",         "password12"),
    ("Cynthia",   "Phillips",     "cynthia@gmail.com",        "welcome12345"),
    ("Kathleen",  "Campbell",     "kathleen@gmail.com",       "pass12345"),
    ("Amy",       "Parker",       "amy@gmail.com",            "qwerty12345"),
};

foreach (var (fn, ln, email, pwd) in registrations)
{
    bool ok = registrationService.Register(fn, ln, email, pwd);
    Console.WriteLine($"  {fn,-10} {ln,-12} | {email,-30} => {(ok ? "✓ Muvaffaqiyatli" : "✗ Xato")}");
}

// Duplicate email sinovi
bool dupResult = registrationService.Register("Ali", "Test", "ali.valiyev@gmail.com", "Password1");
Console.WriteLine($"\n  Duplicate email sinovi => {(dupResult ? "✓" : "✗ Bloklandi (to'g'ri)")}");

//  2. Get (pagination)

var page1 = userService.Get(pageSize: 10, pageToken: 0);
Console.WriteLine($"  Sahifa 1 (size=10, token=0):");
PrintUsers(page1);

var page2 = userService.Get(pageSize: 10, pageToken: 3);
Console.WriteLine($"\n  Sahifa 2 (size=10, token=3):");
PrintUsers(page2);

//  3. Search — konsoldan keyword
Console.WriteLine("         SEARCH");
Console.Write("  Kalit so'z kiriting: ");
string keyword = Console.ReadLine() ?? "ali";

var searchResult = userService.Search(keyword, pageSize: 10, pageToken: 0);
Console.WriteLine($"\n  \"{keyword}\" bo'yicha topildi: {searchResult.Count} ta");
PrintUsers(searchResult);

//  4. Filter

var filterModel = new UserFilterModel
{
    FirstName = "Ali",
    LastName = null,
    PageSize = 10,
    PageToken = 0
};

var filtered = userService.Filter(filterModel);
Console.WriteLine($"  FirstName=\"Ali\" bo'yicha filter: {filtered.Count} ta");
PrintUsers(filtered);

//  5. Update

var allUsers = userService.Get(pageSize: 10, pageToken: 0);
var firstUser = allUsers.First();

Console.WriteLine($"  Avval:  {firstUser.FirstName} {firstUser.LastName}");

firstUser.FirstName = "Alisher";
firstUser.LastName = "Navoiy";
firstUser.EmailAddress = "alisher.navoiy@classic.uz";
var updated = userService.Update(firstUser);

Console.WriteLine($"  Keyin:  {updated.FirstName} {updated.LastName} | {updated.EmailAddress}");

//  6. Delete (soft)

var secondUser = allUsers.Skip(1).First();
Console.WriteLine($"  O'chirilmoqda: {secondUser.FirstName} (Id={secondUser.Id})");
userService.Delete(secondUser.Id);

// Delete bo'lgan user endi Get da chiqmasligi kerak
var afterDelete = userService.Get(pageSize: 10, pageToken: 0);
bool stillExists = afterDelete.Any(u => u.Id == secondUser.Id);
Console.WriteLine($"  Delete keyin ro'yxatda bor?: {(stillExists ? "Ha (xato)" : "Yo'q (to'g'ri ✓)")}");

//  7. Credentials tekshirish

var thirdUser = allUsers.Skip(2).First();
var creds = userCredentialsService.GetByUserId(thirdUser.Id);
Console.WriteLine($"  {thirdUser.FirstName} credential: {(creds != null ? $"UserId={creds.UserId}, Pwd={creds.Password}" : "Topilmadi")}");

Console.WriteLine("\n  Noto'g'ri parol sinovi (qisqa):");
try { userCredentialsService.Add(Guid.NewGuid(), "weak"); }
catch (Exception ex) { Console.WriteLine($"  ✗ Exception: {ex.Message}"); }

Console.WriteLine();

//  Helper

static void PrintUsers(List<User> users)
{
    if (!users.Any()) { Console.WriteLine("  (bo'sh)"); return; }
    foreach (var u in users)
        Console.WriteLine($"  [{u.Id.ToString()[..8]}] {u.FirstName,-10} {u.LastName,-12} | {u.EmailAddress,-32} | Deleted={u.IsDeleted}");
}