using System;
using System.Collections.Generic;
using System.Linq;

namespace VacationPlanner
{
    // ==================== ENUMS ====================

    enum MessageType
    {
        Underage,
        GoldenAger
    }

    enum EmailTemplate
    {
        Welcome,
        Processing,
        Confirmation
    }

    // ==================== CONSTANTS ====================

    static class Constants
    {
        public const string CompanyName = "The Travel Guru";
        public const string NameToken = "{{Name}}";
        public const string CompanyNameToken = "{{CompanyName}}";
        public const string TicketDateToken = "{{TicketDate}}";

        public const int MinAge = 18;
        public const int MaxAge = 90;
    }

    // ==================== CUSTOM EXCEPTIONS ====================

    class InvalidUserDataException : Exception
    {
        public InvalidUserDataException(string message) : base(message) { }
    }

    // ==================== RESULT CLASSES ====================

    class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public static ValidationResult Success()
        {
            return new ValidationResult { IsValid = true };
        }

        public static ValidationResult Failure(string errorMessage)
        {
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = errorMessage
            };
        }
    }

    class RegistrationResult
    {
        public bool Success { get; set; }
        public User User { get; set; }
        public string ErrorMessage { get; set; }
    }

    // ==================== MODELS ====================

    class User
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        // Constructor with validation (Domain logic)
        public User(string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidUserDataException("Ism bo'sh bo'lishi mumkin emas");
            }

            if (ContainsDigit(name))
            {
                throw new InvalidUserDataException("Ism raqam qatnashmasligi kerak");
            }

            if (age < 0)
            {
                throw new InvalidUserDataException("Yosh manfiy bo'lishi mumkin emas");
            }

            if (age > 150)
            {
                throw new InvalidUserDataException("Yosh juda katta");
            }

            Name = name;
            Age = age;
        }

        // Faqat ism bilan yaratish (age noma'lum bo'lgan holat uchun)
        public User(string name) : this(name, 0)
        {
        }

        private bool ContainsDigit(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAgeInRange(int minAge, int maxAge)
        {
            return Age >= minAge && Age <= maxAge;
        }
    }

    class Flight
    {
        public DateTime DepartureTime { get; private set; }
        public int AvailableSeats { get; private set; }

        public Flight(DateTime departureTime, int availableSeats)
        {
            if (availableSeats < 0)
            {
                throw new ArgumentException("Bo'sh o'rinlar soni manfiy bo'lishi mumkin emas");
            }

            DepartureTime = departureTime;
            AvailableSeats = availableSeats;
        }

        public bool CanAccommodate(int groupSize)
        {
            return AvailableSeats >= groupSize;
        }

        public void BookSeats(int count)
        {
            if (count > AvailableSeats)
            {
                throw new InvalidOperationException("Yetarli bo'sh o'rin yo'q");
            }

            AvailableSeats -= count;
        }
    }

    // ==================== SERVICES ====================

    class UserService
    {
        private Dictionary<MessageType, string> _messages;

        public UserService()
        {
            InitializeMessages();
        }

        private void InitializeMessages()
        {
            _messages = new Dictionary<MessageType, string>();
            _messages.Add(MessageType.Underage,
                "Uzr, hurmatli " + Constants.NameToken + " siz loyihadan foydalanish uchun kichkinasiz");
            _messages.Add(MessageType.GoldenAger,
                "Uzr, hurmatli " + Constants.NameToken + " loyiha yoshlar uchun mo'ljallangan");
        }

        // UI'dan ajratilgan - faqat data validation
        public ValidationResult ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return ValidationResult.Failure("Ism bo'sh bo'lishi mumkin emas");
            }

            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]))
                {
                    return ValidationResult.Failure("Ism raqam qatnashmasligi kerak");
                }
            }

            return ValidationResult.Success();
        }

        // UI'dan ajratilgan - faqat data validation
        public ValidationResult ValidateAge(int age, string userName)
        {
            if (age < Constants.MinAge)
            {
                string message = _messages[MessageType.Underage]
                    .Replace(Constants.NameToken, userName);
                return ValidationResult.Failure(message);
            }

            if (age > Constants.MaxAge)
            {
                string message = _messages[MessageType.GoldenAger]
                    .Replace(Constants.NameToken, userName);
                return ValidationResult.Failure(message);
            }

            return ValidationResult.Success();
        }

        // UI'dan ajratilgan - faqat User yaratish
        public User CreateUser(string name, int age)
        {
            try
            {
                return new User(name, age);
            }
            catch (InvalidUserDataException ex)
            {
                throw ex; // Domain validation failed
            }
        }

        public List<User> GetExistingUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User("Ali"));
            users.Add(new User("Vali"));
            users.Add(new User("Sami"));
            users.Add(new User("Fotima"));
            return users;
        }
    }

    class FlightService
    {
        private List<Flight> _flights;

        public FlightService()
        {
            InitializeFlights();
        }

        private void InitializeFlights()
        {
            _flights = new List<Flight>();
            _flights.Add(new Flight(new DateTime(2026, 3, 15, 10, 30, 0), 3));
            _flights.Add(new Flight(new DateTime(2026, 3, 20, 14, 0, 0), 2));
            _flights.Add(new Flight(new DateTime(2026, 3, 25, 9, 0, 0), 6));
        }

        // UI'dan ajratilgan - faqat parvoz topish va bron qilish
        public Flight FindAndBookFlight(int groupSize)
        {
            // Sanalar bo'yicha tartiblash
            var sortedFlights = _flights.OrderBy(f => f.DepartureTime).ToList();

            foreach (Flight flight in sortedFlights)
            {
                if (flight.CanAccommodate(groupSize))
                {
                    flight.BookSeats(groupSize);
                    return flight;
                }
            }

            return null; // Mos parvoz topilmadi
        }

        public List<Flight> GetAllFlights()
        {
            return new List<Flight>(_flights);
        }
    }

    class EmailService
    {
        private Dictionary<EmailTemplate, string> _emailTemplates;

        public EmailService()
        {
            InitializeEmailTemplates();
        }

        private void InitializeEmailTemplates()
        {
            _emailTemplates = new Dictionary<EmailTemplate, string>();

            _emailTemplates.Add(EmailTemplate.Welcome,
                "Hello " + Constants.NameToken + ". Welcome to onboard. " + Constants.CompanyNameToken + " Team.");

            _emailTemplates.Add(EmailTemplate.Processing,
                "Your data is being processed and we will inform updates for you as soon as possible. " + Constants.CompanyNameToken + " Team");

            _emailTemplates.Add(EmailTemplate.Confirmation,
                "Congratulations! Your flight ticket is booked for " + Constants.TicketDateToken + ". " + Constants.CompanyNameToken + " Team.");
        }

        // UI'dan ajratilgan - faqat email content generate qilish
        public List<string> GenerateEmailsForUser(User user, DateTime flightDate)
        {
            List<string> emails = new List<string>();

            // Welcome email
            emails.Add(ProcessTemplate(EmailTemplate.Welcome, user.Name, flightDate));

            // Processing email
            emails.Add(ProcessTemplate(EmailTemplate.Processing, user.Name, flightDate));

            // Confirmation email
            emails.Add(ProcessTemplate(EmailTemplate.Confirmation, user.Name, flightDate));

            return emails;
        }

        private string ProcessTemplate(EmailTemplate template, string userName, DateTime flightDate)
        {
            string email = _emailTemplates[template];
            email = email.Replace(Constants.NameToken, userName);
            email = email.Replace(Constants.CompanyNameToken, Constants.CompanyName);
            email = email.Replace(Constants.TicketDateToken, flightDate.ToString("dd.MM.yyyy HH:mm"));
            return email;
        }
    }

    // ==================== UI LAYER ====================

    class ConsoleUI
    {
        private UserService _userService;

        public ConsoleUI(UserService userService)
        {
            _userService = userService;
        }

        public void ShowWelcomeMessage()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("  " + Constants.CompanyName + " ga xush kelibsiz!");
            Console.WriteLine("========================================\n");
        }

        public void ShowSuccessMessage(string message)
        {
            Console.WriteLine("\n✅ " + message);
        }

        public void ShowErrorMessage(string message)
        {
            Console.WriteLine("\n❌ " + message);
        }

        public void ShowFarewellMessage()
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("  Barcha jarayonlar yakunlandi!");
            Console.WriteLine("  Yaxshi sayohat tilaymiz! ✈️");
            Console.WriteLine("========================================");
        }

        public void ShowFlightInfo(Flight flight, int groupSize, int seatsBeforeBooking)
        {
            Console.WriteLine("\n--- Biletlarni topish ---\n");
            Console.WriteLine("✓ Mos parvoz topildi!");
            Console.WriteLine("  Sana: " + flight.DepartureTime.ToString("dd.MM.yyyy HH:mm"));
            Console.WriteLine("  Guruh: " + groupSize + " kishi");
            Console.WriteLine("  Bo'sh o'rinlar (oldin): " + seatsBeforeBooking);
            Console.WriteLine("\n✓ Joylar bron qilindi!");
            Console.WriteLine("  Qolgan bo'sh joylar: " + flight.AvailableSeats + "\n");
        }

        public void ShowEmails(User user, List<string> emails)
        {
            Console.WriteLine(">>> " + user.Name + " uchun:\n");

            for (int i = 0; i < emails.Count; i++)
            {
                Console.WriteLine("Email #" + (i + 1) + ":");
                Console.WriteLine(emails[i]);
                Console.WriteLine();
            }

            Console.WriteLine("---\n");
        }

        // UI layer - user input
        public RegistrationResult RegisterNewUser()
        {
            Console.WriteLine("--- Ro'yxatdan o'tish ---\n");

            // Ism olish
            string name = GetValidName();
            if (name == null)
            {
                return new RegistrationResult { Success = false };
            }

            // Yosh olish
            int age = GetValidAge();
            if (age == -1)
            {
                return new RegistrationResult { Success = false };
            }

            // Age validation (business logic)
            ValidationResult ageValidation = _userService.ValidateAge(age, name);
            if (!ageValidation.IsValid)
            {
                ShowErrorMessage(ageValidation.ErrorMessage);
                return new RegistrationResult
                {
                    Success = false,
                    ErrorMessage = ageValidation.ErrorMessage
                };
            }

            // User yaratish
            try
            {
                User user = _userService.CreateUser(name, age);
                return new RegistrationResult
                {
                    Success = true,
                    User = user
                };
            }
            catch (InvalidUserDataException ex)
            {
                ShowErrorMessage(ex.Message);
                return new RegistrationResult
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        private string GetValidName()
        {
            while (true)
            {
                Console.Write("Ismingizni kiriting: ");
                string name = Console.ReadLine();

                ValidationResult result = _userService.ValidateName(name);
                if (result.IsValid)
                {
                    return name;
                }

                ShowErrorMessage(result.ErrorMessage);
            }
        }

        private int GetValidAge()
        {
            while (true)
            {
                Console.Write("Yoshingizni kiriting: ");
                string ageInput = Console.ReadLine();

                int age;
                if (int.TryParse(ageInput, out age))
                {
                    return age;
                }

                ShowErrorMessage("Noto'g'ri format! Iltimos, faqat raqam kiriting.");
            }
        }
    }

    // ==================== APPLICATION ORCHESTRATOR ====================

    class VacationPlannerApp
    {
        private UserService _userService;
        private FlightService _flightService;
        private EmailService _emailService;
        private ConsoleUI _ui;

        public VacationPlannerApp()
        {
            _userService = new UserService();
            _flightService = new FlightService();
            _emailService = new EmailService();
            _ui = new ConsoleUI(_userService);
        }

        public void Run()
        {
            // 1. Xush kelibsiz
            _ui.ShowWelcomeMessage();

            // 2. Mavjud foydalanuvchilarni yuklash
            List<User> users = _userService.GetExistingUsers();

            // 3. Yangi foydalanuvchini ro'yxatdan o'tkazish
            RegistrationResult registrationResult = _ui.RegisterNewUser();
            if (!registrationResult.Success)
            {
                return; // Ro'yxatdan o'tish muvaffaqiyatsiz
            }

            // 4. Guruhga qo'shish
            users.Add(registrationResult.User);
            _ui.ShowSuccessMessage("Ro'yxatdan o'tish muvaffaqiyatli yakunlandi!");

            // 5. Parvoz topish va bron qilish
            int groupSize = users.Count;
            Flight bookedFlight = _flightService.FindAndBookFlight(groupSize);

            if (bookedFlight == null)
            {
                _ui.ShowErrorMessage("Guruh uchun mos parvoz topilmadi.");
                return;
            }

            // Flight info ko'rsatish (seats already booked)
            int seatsBeforeBooking = bookedFlight.AvailableSeats + groupSize;
            _ui.ShowFlightInfo(bookedFlight, groupSize, seatsBeforeBooking);

            // 6. Emaillarni generate qilish va ko'rsatish
            Console.WriteLine("--- Email xabarnomalar ---\n");

            foreach (User user in users)
            {
                List<string> emails = _emailService.GenerateEmailsForUser(user, bookedFlight.DepartureTime);
                _ui.ShowEmails(user, emails);
            }

            // 7. Xayrlashuv
            _ui.ShowFarewellMessage();
        }
    }

    // ==================== MAIN PROGRAM ====================

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            VacationPlannerApp app = new VacationPlannerApp();
            app.Run();
        }
    }
}