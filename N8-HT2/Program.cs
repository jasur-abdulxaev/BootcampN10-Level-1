namespace VacationPlanner
{
    class Program
    {
        // Konstantalar
        const string CompanyName = "The Travel Guru";
        const string NameToken = "{{Name}}";
        const string CompanyNameToken = "{{CompanyName}}";
        const string TicketDateToken = "{{TicketDate}}";

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Ma'lumotlarni tayyorlash
            Dictionary<string, string> messages = InitializeMessages();
            LinkedList<string> emails = InitializeEmails();
            Queue<string> users = InitializeUsers();
            Dictionary<DateTime, int> flights = InitializeFlights();

            ShowWelcomeMessage();

            // 1. Ro'yxatdan o'tish jarayoni
            string newUserName = RegisterNewUser(messages);
            if (newUserName == null)
            {
                return; // Dastur tugaydi
            }

            users.Enqueue(newUserName);
            ShowSuccessMessage("\n✓ Ro'yxatdan o'tish muvaffaqiyatli yakunlandi!\n");

            // 2. Biletlarni topish
            DateTime selectedFlightDate = FindFlight(users.Count, flights);
            if (selectedFlightDate == DateTime.MinValue)
            {
                Console.WriteLine("Afsuski, guruh uchun mos parvoz topilmadi.");
                return;
            }

            // 3. Emaillarni jo'natish
            SendEmailsToAllUsers(users, emails, selectedFlightDate);

            ShowFarewellMessage();
        }

        // Messages ni yaratish
        static Dictionary<string, string> InitializeMessages()
        {
            Dictionary<string, string> messages = new Dictionary<string, string>();
            messages.Add("Underage", "Uzr, hurmatli " + NameToken + " siz loyihadan foydalanish uchun kichkinasiz");
            messages.Add("GoldenAger", "Uzr, hurmatli " + NameToken + " loyiha yoshlar uchun mo'ljallangan");
            return messages;
        }

        // Emails ni yaratish
        static LinkedList<string> InitializeEmails()
        {
            LinkedList<string> emails = new LinkedList<string>();
            emails.AddLast("Hello " + NameToken + ". Welcome to onboard. " + CompanyNameToken + " Team.");
            emails.AddLast("Your data is being processed and we will inform updates for you as soon as possible. " + CompanyNameToken + " Team");
            emails.AddLast("Congratulations! Your flight ticket is booked for " + TicketDateToken + ". " + CompanyNameToken + " Team.");
            return emails;
        }

        // Oldindan ro'yxatdan o'tgan foydalanuvchilar
        static Queue<string> InitializeUsers()
        {
            Queue<string> users = new Queue<string>();
            users.Enqueue("Ali");
            users.Enqueue("Vali");
            users.Enqueue("Sami");
            users.Enqueue("Fotima");
            return users;
        }

        // Parvozlarni yaratish
        static Dictionary<DateTime, int> InitializeFlights()
        {
            Dictionary<DateTime, int> flights = new Dictionary<DateTime, int>();
            flights.Add(new DateTime(2026, 3, 15, 10, 30, 0), 3);
            flights.Add(new DateTime(2026, 3, 20, 14, 0, 0), 2);
            flights.Add(new DateTime(2026, 3, 25, 9, 0, 0), 6);
            return flights;
        }

        // Xush kelibsiz xabari
        static void ShowWelcomeMessage()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("  " + CompanyName + " ga xush kelibsiz!");
            Console.WriteLine("========================================\n");
            Console.WriteLine("--- Ro'yxatdan o'tish ---\n");
        }

        // Yangi foydalanuvchini ro'yxatdan o'tkazish
        static string RegisterNewUser(Dictionary<string, string> messages)
        {
            // Ismni olish va tekshirish
            string userName = GetValidName();
            if (userName == null)
            {
                return null;
            }

            // Yoshni olish va tekshirish
            int age = GetAge();
            if (age == -1)
            {
                Console.WriteLine("Noto'g'ri yosh kiritildi!");
                return null;
            }

            // Yosh bo'yicha tekshirish
            if (!ValidateAge(age, userName, messages))
            {
                return null;
            }

            return userName;
        }

        // To'g'ri ismni olish
        static string GetValidName()
        {
            while (true)
            {
                Console.Write("Ismingizni kiriting: ");
                string name = Console.ReadLine();

                if (IsValidName(name))
                {
                    return name;
                }

                Console.WriteLine("Invalid name\n");
            }
        }

        // Ismni tekshirish (son bo'lmasligi kerak)
        static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]))
                {
                    return false;
                }
            }

            return true;
        }

        // Yoshni olish
        static int GetAge()
        {
            Console.Write("Yoshingizni kiriting: ");
            string ageInput = Console.ReadLine();

            try
            {
                return int.Parse(ageInput);
            }
            catch
            {
                return -1;
            }
        }

        // Yoshni tekshirish
        static bool ValidateAge(int age, string userName, Dictionary<string, string> messages)
        {
            if (age < 18)
            {
                string message = messages["Underage"].Replace(NameToken, userName);
                Console.WriteLine("\n" + message);
                return false;
            }
            else if (age > 90)
            {
                string message = messages["GoldenAger"].Replace(NameToken, userName);
                Console.WriteLine("\n" + message);
                return false;
            }

            return true;
        }

        // Parvozni topish
        static DateTime FindFlight(int groupSize, Dictionary<DateTime, int> flights)
        {
            Console.WriteLine("--- Biletlarni topish ---\n");

            foreach (KeyValuePair<DateTime, int> flight in flights)
            {
                if (flight.Value >= groupSize)
                {
                    ShowFlightInfo(flight.Key, groupSize, flight.Value);
                    return flight.Key;
                }
            }

            return DateTime.MinValue;
        }

        // Parvoz ma'lumotlarini ko'rsatish
        static void ShowFlightInfo(DateTime flightDate, int groupSize, int availableSeats)
        {
            Console.WriteLine("✓ Mos parvoz topildi!");
            Console.WriteLine("  Sana: " + flightDate.ToString("dd.MM.yyyy HH:mm"));
            Console.WriteLine("  Guruh: " + groupSize + " kishi");
            Console.WriteLine("  Bo'sh o'rinlar: " + availableSeats + "\n");
        }

        // Barcha foydalanuvchilarga emaillarni jo'natish
        static void SendEmailsToAllUsers(Queue<string> users, LinkedList<string> emails, DateTime flightDate)
        {
            Console.WriteLine("--- Email xabarnomalar ---\n");

            Queue<string> tempUsers = new Queue<string>(users);

            while (tempUsers.Count > 0)
            {
                string userName = tempUsers.Dequeue();
                SendEmailsToUser(userName, emails, flightDate);
            }
        }

        // Bitta foydalanuvchiga emaillarni jo'natish
        static void SendEmailsToUser(string userName, LinkedList<string> emails, DateTime flightDate)
        {
            Console.WriteLine(">>> " + userName + " uchun:\n");

            LinkedListNode<string> currentEmail = emails.First;
            int emailNumber = 1;

            while (currentEmail != null)
            {
                string processedEmail = ProcessEmailTemplate(currentEmail.Value, userName, flightDate);
                ShowEmail(emailNumber, processedEmail);

                currentEmail = currentEmail.Next;
                emailNumber++;
            }

            Console.WriteLine("---");
            Console.WriteLine();
        }

        // Email shablonini qayta ishlash
        static string ProcessEmailTemplate(string template, string userName, DateTime flightDate)
        {
            string email = template;
            email = email.Replace(NameToken, userName);
            email = email.Replace(CompanyNameToken, CompanyName);
            email = email.Replace(TicketDateToken, flightDate.ToString("dd.MM.yyyy HH:mm"));
            return email;
        }

        // Emailni ko'rsatish
        static void ShowEmail(int number, string email)
        {
            Console.WriteLine("Email #" + number + ":");
            Console.WriteLine(email);
            Console.WriteLine();
        }

        // Muvaffaqiyatli xabar
        static void ShowSuccessMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Xayrlashuv xabari
        static void ShowFarewellMessage()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("  Barcha jarayonlar yakunlandi!");
            Console.WriteLine("  Yaxshi sayohat tilaymiz! ✈️");
            Console.WriteLine("========================================");
        }
    }
}