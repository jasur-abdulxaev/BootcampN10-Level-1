using System;
using System.Collections.Generic;
using System.Text;

namespace N36_T1.Models;

public record Manager(string FirstName, string LastName, int Age, string EmailAddress, string Password, IEnumerable<Employee> Employees) : Person(FirstName, LastName, Age);
