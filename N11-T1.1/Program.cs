
// === MODEL ===
class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string firstName, string lastName, string phoneNumber, string email)
    {
        // Validatsiya — noto'g'ri ma'lumot kiritib bo'lmaydi
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("Ism bo'sh bo'lishi mumkin emas!");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Familiya bo'sh bo'lishi mumkin emas!");

        if (!IsValidPhone(phoneNumber))
            throw new ArgumentException("Telefon raqam noto'g'ri! Format: +998 XX XXX XX XX");

        if (!IsValidEmail(email))
            throw new ArgumentException("Email manzil noto'g'ri!");

        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public override string ToString()
    {
        string fullName = $"{FirstName} {LastName}";
        return $"{fullName,-25}{PhoneNumber,-22}{Email}";
    }

    // Private validatsiya metodlari (Encapsulation)
    private bool IsValidPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone)) return false;
        string digits = new string(phone.Where(char.IsDigit).ToArray());
        return digits.Length >= 9;
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;
        return email.Contains('@') && email.Contains('.');
    }
}

// === SERVICE ===
class ContactList
{
    private List<Contact> _contacts = new();

    public void Add(Contact contact)
    {
        _contacts.Add(contact);
    }

    public List<Contact> GetAll()
    {
        return _contacts.ToList();
    }

    // Ism YOKI familiya bo'yicha qidiradi va NATIJANI QAYTARADI
    public List<Contact> Search(string keyword)
    {
        return _contacts
            .Where(c =>
                c.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public int Count => _contacts.Count;
}

// === PROGRAM (UI) ===
class Program
{
    static void Main()
    {
        var contactList = new ContactList();

        contactList.Add(new Contact("G'ishtmat", "Teshavoyev", "+998 99 123 45 67", "gishtmat.dizayner@gmail.com"));
        contactList.Add(new Contact("G'ishtmat", "G'ishtmatov", "+998 99 234 56 78", "gishtmat.007@gmail.com"));
        contactList.Add(new Contact("G'ishtmat", "G'ayratov", "+998 99 345 67 89", "gishtmat.coder@gmail.com"));
        contactList.Add(new Contact("Ali", "Valiyev", "+998 90 111 22 33", "ali.valiyev@gmail.com"));
        contactList.Add(new Contact("Malika", "Karimova", "+998 93 444 55 66", "malika.k@gmail.com"));

        Console.WriteLine("  CONTACT LIST DASTURI\n");

        while (true)
        {
            Console.WriteLine("\n  Choose a command ( display all - d / search - f / quit - q )");
            Console.Write("  > ");
            string command = Console.ReadLine()?.Trim().ToLower();

            switch (command)
            {
                case "d":
                    DisplayContacts(contactList.GetAll(), "Barcha kontaktlar");
                    break;

                case "f":
                    Console.Write("  Ism yoki familiyani kiriting: ");
                    string keyword = Console.ReadLine()?.Trim();

                    if (string.IsNullOrEmpty(keyword))
                    {
                        Console.WriteLine("  Qidiruv so'zi kiritilmadi!");
                        break;
                    }

                    var results = contactList.Search(keyword);
                    DisplayContacts(results, $"Qidiruv: '{keyword}'");
                    break;

                case "q":
                    Console.WriteLine("\n  Dastur yakunlandi. Xayr!");
                    return;

                default:
                    Console.WriteLine("  Noto'g'ri buyruq! d, f yoki q kiriting.");
                    break;
            }
        }
    }

    // UI method — kontaktlar ro'yxatini ekranga chiqarish
    static void DisplayContacts(List<Contact> contacts, string title)
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("\n  Natija topilmadi.");
            return;
        }

        Console.WriteLine($"\n  === {title} ({contacts.Count} ta) ===\n");
        Console.WriteLine($"  {"Ism Familiya",-25}{"Telefon",-22}{"Email"}");
        Console.WriteLine("  " + new string('-', 70));

        foreach (var contact in contacts)
        {
            Console.WriteLine($"  {contact}");
        }
    }
}