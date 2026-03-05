using System.Text;

namespace PasswordGeneratorSystem
{
    // Base password generator service
    public class PasswordGenerator
    {
        protected int Length { get; set; }
        protected bool HasLetters { get; set; }
        protected bool HasDigits { get; set; }

        protected Random random;

        protected const string Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        protected const string Digits = "0123456789";

        // Constructor with optional hasDigits parameter
        public PasswordGenerator(int length, bool hasLetters, bool hasDigits = false)
        {
            if (length < 4)
                throw new ArgumentException("Password length must be at least 4 characters");

            Length = length;
            HasLetters = hasLetters;
            HasDigits = hasDigits;
            random = new Random();
        }

        public string Generate()
        {
            StringBuilder characterSet = new StringBuilder();

            if (HasLetters)
                characterSet.Append(Letters);

            if (HasDigits)
                characterSet.Append(Digits);

            if (characterSet.Length == 0)
                throw new InvalidOperationException("At least one character type must be enabled");

            StringBuilder password = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                int index = random.Next(characterSet.Length);
                password.Append(characterSet[index]);
            }

            return password.ToString();
        }
    }

    // Secure password generator - inherits from PasswordGenerator
    public class SecurePasswordGenerator : PasswordGenerator
    {
        protected const string Symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        public SecurePasswordGenerator(int length, bool hasLetters, bool hasDigits = false)
            : base(length, hasLetters, hasDigits)
        {
        }

        public string GenerateSecure(bool hasSymbols)
        {
            StringBuilder characterSet = new StringBuilder();

            if (HasLetters)
                characterSet.Append(Letters);

            if (HasDigits)
                characterSet.Append(Digits);

            if (hasSymbols)
                characterSet.Append(Symbols);

            if (characterSet.Length == 0)
                throw new InvalidOperationException("At least one character type must be enabled");

            StringBuilder password = new StringBuilder();
            List<char> requiredChars = new List<char>();

            // Ensure at least one character from each enabled type
            if (HasLetters)
                requiredChars.Add(Letters[random.Next(Letters.Length)]);

            if (HasDigits)
                requiredChars.Add(Digits[random.Next(Digits.Length)]);

            if (hasSymbols)
                requiredChars.Add(Symbols[random.Next(Symbols.Length)]);

            // Add required characters first
            foreach (char c in requiredChars)
            {
                password.Append(c);
            }

            // Fill remaining length with random characters
            for (int i = password.Length; i < Length; i++)
            {
                int index = random.Next(characterSet.Length);
                password.Append(characterSet[index]);
            }

            // Shuffle the password to randomize position of required characters
            return ShuffleString(password.ToString());
        }

        protected string ShuffleString(string input)
        {
            char[] array = input.ToCharArray();
            int n = array.Length;

            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            return new string(array);
        }
    }

    // Unique password generator - inherits from SecurePasswordGenerator
    public class UniquePasswordGenerator : SecurePasswordGenerator
    {
        private HashSet<string> generatedPasswords;

        public UniquePasswordGenerator(int length, bool hasLetters, bool hasDigits = false)
            : base(length, hasLetters, hasDigits)
        {
            generatedPasswords = new HashSet<string>();
        }

        public string GenerateUniquePassword()
        {
            string password;
            int attempts = 0;
            const int maxAttempts = 1000;

            do
            {
                // Generate secure password with symbols enabled
                password = GenerateSecure(hasSymbols: true);
                attempts++;

                if (attempts > maxAttempts)
                {
                    throw new InvalidOperationException(
                        "Could not generate unique password after maximum attempts. " +
                        "Consider increasing password length.");
                }

            } while (generatedPasswords.Contains(password));

            generatedPasswords.Add(password);
            return password;
        }

        public int GetGeneratedPasswordCount()
        {
            return generatedPasswords.Count;
        }

        public void ClearGeneratedPasswords()
        {
            generatedPasswords.Clear();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Password Generator System Demo ===\n");

            // 1. PasswordGenerator
            Console.WriteLine("1. Basic PasswordGenerator:");
            Console.WriteLine(new string('-', 50));
            PasswordGenerator basicGenerator = new PasswordGenerator(
                length: 12,
                hasLetters: true,
                hasDigits: true
            );

            string basicPassword = basicGenerator.Generate();
            Console.WriteLine($"Generated Password: {basicPassword}");
            Console.WriteLine($"Length: {basicPassword.Length}");
            Console.WriteLine($"Contains Letters: {basicPassword.Any(char.IsLetter)}");
            Console.WriteLine($"Contains Digits: {basicPassword.Any(char.IsDigit)}");
            Console.WriteLine();

            // 2. SecurePasswordGenerator
            Console.WriteLine("2. SecurePasswordGenerator:");
            Console.WriteLine(new string('-', 50));
            SecurePasswordGenerator secureGenerator = new SecurePasswordGenerator(
                length: 16,
                hasLetters: true,
                hasDigits: true
            );

            string securePassword = secureGenerator.GenerateSecure(hasSymbols: true);
            Console.WriteLine($"Secure Password: {securePassword}");
            Console.WriteLine($"Length: {securePassword.Length}");
            Console.WriteLine($"Contains Letters: {securePassword.Any(char.IsLetter)}");
            Console.WriteLine($"Contains Digits: {securePassword.Any(char.IsDigit)}");
            Console.WriteLine($"Contains Symbols: {securePassword.Any(c => "!@#$%^&*()_+-=[]{}|;:,.<>?".Contains(c))}");
            Console.WriteLine();

            // 3. UniquePasswordGenerator
            Console.WriteLine("3. UniquePasswordGenerator:");
            Console.WriteLine(new string('-', 50));
            UniquePasswordGenerator uniqueGenerator = new UniquePasswordGenerator(
                length: 14,
                hasLetters: true,
                hasDigits: true
            );

            // Generate multiple unique passwords to demonstrate uniqueness
            Console.WriteLine("Generating 5 unique passwords:\n");
            for (int i = 1; i <= 5; i++)
            {
                string uniquePassword = uniqueGenerator.GenerateUniquePassword();
                Console.WriteLine($"Password {i}: {uniquePassword}");
            }

            Console.WriteLine($"\nTotal unique passwords generated: {uniqueGenerator.GetGeneratedPasswordCount()}");
            Console.WriteLine();

            // Demonstrate that duplicate passwords are not generated
            Console.WriteLine("Attempting to verify uniqueness:");
            Console.WriteLine(new string('-', 50));
            UniquePasswordGenerator testGenerator = new UniquePasswordGenerator(8, true, true);

            HashSet<string> testSet = new HashSet<string>();
            int duplicateAttempts = 0;

            for (int i = 0; i < 10; i++)
            {
                string pwd = testGenerator.GenerateUniquePassword();
                if (!testSet.Add(pwd))
                {
                    duplicateAttempts++;
                }
            }

            Console.WriteLine($"Generated 10 passwords");
            Console.WriteLine($"All passwords are unique: {duplicateAttempts == 0}");
            Console.WriteLine($"Stored passwords count: {testGenerator.GetGeneratedPasswordCount()}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}