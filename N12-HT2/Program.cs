using System.Text.RegularExpressions;

class Email
{
    private string _to;
    private string _from;
    private string _subject;
    private string _content;

    public string To
    {
        get => _to;
        set
        {
            if (!IsValidEmail(value))
                throw new FormatException($"Invalid email address: {value}");
            _to = value;
        }
    }

    public string From
    {
        get => _from;
        set
        {
            if (!IsValidEmail(value))
                throw new FormatException($"Invalid email address: {value}");
            _from = value;
        }
    }

    public string Subject
    {
        get => _subject;
        set
        {
            if (!IsValidText(value))
                throw new FormatException("Subject cannot be null ot empty");
            _subject = value;
        }
    }

    public string Content
    {
        get => _content;
        set
        {
            if (!IsValidText(value))
                throw new FormatException("Content cannot be null or empty");
            _content = value;
        }
    }

    public Email(string to, string from, string subject, string content)
    {
        To = to;
        From = from;
        Subject = subject;
        Content = content;
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    private bool IsValidText(string text)
    {
        return !string.IsNullOrWhiteSpace(text);
    }

    public override string ToString()
    {
        return $"""
        ================================
         From:    {From}
         To:      {To}
         Subject: {Subject}
        --------------------------------
         {Content}
        ================================
        """;
    }
}

class Program
{
    static void Main()
    {
        // valid email
        try
        {
            Email validEmail = new Email(
                "john@gmail.com",
                "peter@yahoo.com",
                "Meeting Tomorrow",
                "Hi John, let's meet at 3 PM tomorrow. Best regards, Peter."
            );
            Console.WriteLine("--- Valid Email ---");
            Console.WriteLine(validEmail);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // invalid email
        try
        {
            Email invalidEmail = new Email(
                "john_invalid_email",
                "peter@@yahoo",
                "",
                null
            );
            Console.WriteLine("--- Invalid Email ---");
            Console.WriteLine(invalidEmail);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"--- Invalid Email ---");
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
