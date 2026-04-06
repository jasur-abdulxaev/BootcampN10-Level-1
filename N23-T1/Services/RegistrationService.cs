using UserRegistrationApp.Interfaces;
using UserRegistrationApp.Models;
using UserRegistrationApp.Validators;

namespace UserRegistrationApp.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRepository<User> _repository;
        private readonly UserValidator _validator;

        public RegistrationService(IRepository<User> repository, UserValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Register(string email, string password)
        {
            var existingUser = _repository.Find(u => u.EmailAddress == email);

            if (existingUser != null)
            {
                Console.WriteLine("Bu email address allaqachon bor");
                return;
            }

            var user = new User
            {
                EmailAddress = email,
                Password = password,
                IsEmailVerified = false,
                IsPhoneVerified = false
            };

            if (!_validator.Validate(user, out string error))
            {
                Console.WriteLine(error);
                return;
            }

            _repository.Add(user);
            Console.WriteLine("User muvaffaqiyatli ro'yxatdan o'tdi");
        }

        public bool Login(string email, string password)
        {
            var user = _repository.Find(u =>
                u.EmailAddress == email &&
                u.Password == password);

            if (user == null)
            {
                Console.WriteLine("Email yoki password noto‘g‘ri");
                return false;
            }

            if (!user.IsEmailVerified || !user.IsPhoneVerified)
            {
                Console.WriteLine("Sorry, you haven't verified your email address / phone number");
                return false;
            }

            return true;
        }
    }
}