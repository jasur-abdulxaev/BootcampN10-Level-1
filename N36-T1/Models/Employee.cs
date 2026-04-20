namespace N36_T1.Models;

public record Employee(string FirstName, string LastName, int Age, string EmailAddress, decimal Salary) : Person(FirstName, LastName, Age);
