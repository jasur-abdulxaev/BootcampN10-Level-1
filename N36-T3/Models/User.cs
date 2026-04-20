namespace N36_T3.Models;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public User(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
    }
}
