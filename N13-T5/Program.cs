Console.OutputEncoding = System.Text.Encoding.UTF8;

const string password = "YouWillNeverGuess";

var messages = new Dictionary<string, Dictionary<string, string>>
{
    ["SuccessfulRegistration"] = new Dictionary<string, string>
    {
        ["u"] = "Tizimga muvaffaqiyatli ro'yxatdan o'tdingiz!",
        ["j"] = "登録が成功しました！",
        ["g"] = "Registrierung erfolgreich!"
    },
    ["EnterYourPassword"] = new Dictionary<string, string>
    {
        ["u"] = "Parolingizni kiriting",
        ["j"] = "パスワードを入力してください",
        ["g"] = "Geben Sie Ihr Passwort ein"
    },
    ["AccountBlocked"] = new Dictionary<string, string>
    {
        ["u"] = "Akkount bloklangan",
        ["j"] = "アカウントがブロックされました",
        ["g"] = "Konto gesperrt"
    }
};

Console.Write("Tilni tanlang (uzbek - u, japan - j, german - g): ");
string lang = Console.ReadLine().Trim().ToLower();

Console.WriteLine(messages["EnterYourPassword"][lang]);
string input = Console.ReadLine();

if (input == password)
    Console.WriteLine(messages["SuccessfulRegistration"][lang]);
else
    Console.WriteLine(messages["AccountBlocked"][lang]);
