
using N38_HT1.Models;

var users = new List<User>
{
    new User("Azizbek", "Abdurahmonov", "aizzbekabdura@gmail.com"),
    new User("Sardor", "Abdurahmonov", "sardorabdurahmonov@gmail.com"),
    new User("Jasur", "Abdulhayev", "jasurabdulxaev23@gmail.com"),
    new User("Firdavs", "Asadov", "asadov@gmail.com"),
    new User("Ilxom", "Karimjonov"," marmokcs@gmail.com")
};

var userContainer = new UserContainer(users);
var query = userContainer.Where(user => user.EmailAddress.Contains("gamil"));

Console.WriteLine("Emailini oxiri gmail.com bo'lganlar: ");
foreach (var user in query)
{
    Console.WriteLine(user);
}

Console.WriteLine();

Console.WriteLine(userContainer[userContainer.LastOrDefault().Id]);
Console.WriteLine(userContainer["abdu"]);
Console.WriteLine(userContainer[2]);