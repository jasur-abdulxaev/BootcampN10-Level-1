using Microsoft.Extensions.DependencyInjection;
using UserRegistrationApp.Interfaces;
using UserRegistrationApp.Models;
using UserRegistrationApp.Repositories;
using UserRegistrationApp.Services;
using UserRegistrationApp.Validators;

namespace UserRegistrationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            // DI konfiguratsiya
            services.AddSingleton<IRepository<User>, InMemoryRepository<User>>();
            services.AddSingleton<UserValidator>();
            services.AddSingleton<IRegistrationService, RegistrationService>();

            var provider = services.BuildServiceProvider();

            var registrationService = provider.GetService<IRegistrationService>();

            // 3 ta user
            registrationService.Register("user1@gmail.com", "123");
            registrationService.Register("user2@gmail.com", "456");
            registrationService.Register("user3@gmail.com", "789");

            Console.WriteLine("\n--- Yangi user ---");

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            registrationService.Register(email, password);

            Console.WriteLine("\n--- Login ---");

            Console.Write("Email: ");
            var loginEmail = Console.ReadLine();

            Console.Write("Password: ");
            var loginPassword = Console.ReadLine();

            var result = registrationService.Login(loginEmail, loginPassword);

            Console.WriteLine(result ? "Login success" : "Login failed");
        }
    }
}