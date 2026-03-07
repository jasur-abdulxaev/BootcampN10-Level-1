
namespace NotificationMessages
{
    public class NotificationMessages
    {

        // private dictionary to store the messages
        private Dictionary<string, string> _messages;

        public NotificationMessages()
        {
            _messages = new Dictionary<string, string>
        {
            { "SuccRegistration", "You successfully registered" },
            { "AskPassword", "Enter your password" },
            { "Blocked", "Your account has been blocked" }
        };
        }

        // protected method - key value pair qaytaradi
        protected KeyValuePair<string, string> FindMessages(string messageName)
        {
            // Agar habar topilsa - key value pair qaytaradi, aks holda default qaytaradi
            if (_messages.ContainsKey(messageName))
            {
                return new KeyValuePair<string, string>(messageName, _messages[messageName]);
            }

            return default(KeyValuePair<string, string>);
        }

        // Publik method - faqat habarni kontentini qaytaradi
        public string SearchMessage(string messageName)
        {
            // FindMessage dan foydalanib, habarni topish
            KeyValuePair<string, string> result = FindMessages(messageName);

            // Agar topilmagan bo'lsa - null qaytaradi
            if (result.Equals(default(KeyValuePair<string, string>)))
            {
                return null;
            }

            // Topilsa, faqat value qismini qaytaradi
            return result.Value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // object yaratish
            NotificationMessages messages = new NotificationMessages();

            Console.WriteLine("=== Bor bo'lgan habarlar ===");

            // Bor bo'lgan habarlarni tekshirish
            string message1 = messages.SearchMessage("SuccRegistration");
            Console.WriteLine($"SuccRegistration: {message1}");

            string message2 = messages.SearchMessage("AskPassword");
            Console.WriteLine($"AskPassword: {message2}");

            string message3 = messages.SearchMessage("Blocked");
            Console.WriteLine($"Blocked: {message3}");

            Console.WriteLine("\n=== Yo'q bo'lgan habarlar ===");

            // Yo'q bo'lgan habarlarni tekshirish
            string message4 = messages.SearchMessage("WelcomeMessage");
            Console.WriteLine($"WelcomeMessage: {(message4 == null ? "Topilmadi" : message4)}");

            string message5 = messages.SearchMessage("ErrorMessage");
            Console.WriteLine($"ErrorMessage: {(message5 == null ? "Topilmadi" : message5)}");
        }
    }
}
