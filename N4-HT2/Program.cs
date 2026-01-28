using System.Text;

var existingUsernames = new[]
{
    "jasurbek",
    "jasurbek_robot",
    "jasurbek_kosmonavt",
    "gayrat-app",
    "ali-production",
    "bekzod-pro",
    "jasurbek_legend",
    "jasurbek_ninja"
};

var funWords = new[]
{
    "kosmonavt",
    "ninja",
    "robot",
    "champion",
    "legend"
};

Console.Write("Enter your name: ");
//Foydalanuvchi ism kiritadi agar null bolmasa trim qiladi va kichik harsflar qilib yozadi aks holda "" ni olib ketadi.
var name = Console.ReadLine()?.Trim().ToLower() ?? "";

//Tasodifiy qiziqarli so'z tanlab olish.
var random = new Random();
var funWord = funWords[random.Next(funWords.Length)];

//Username yasaymiz.
var sb = new StringBuilder();
sb.Append(name)
    .Append('_')
    .Append(funWord);

string username = sb.ToString();

//Takrorlanishni tekshirish
bool exists;
int counter = 1;

do
{
    exists = false;

    foreach (var u in existingUsernames)
    {
        if (u == username)
        {
            exists = true;
            break;
        }
    }
    if (exists)
    {
        sb.Clear();
        sb.Append(name)
            .Append('_')
            .Append(funWord)
            .Append(counter);

        username = sb.ToString();
        counter++;
    }
} while (exists);

Console.WriteLine($"Sizga tayyorlangan username: {username}");
