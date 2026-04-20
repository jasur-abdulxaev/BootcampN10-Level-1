using N37_HT1.Enums;

namespace N37_HT1.Models;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public Status Status { get; set; }

    public User(string firstName, string lastName, string emailAddress, Status status)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        Status = status;
    }
}
