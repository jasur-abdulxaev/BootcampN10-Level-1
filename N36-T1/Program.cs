using N36_T1.Models;

var person1 = new Person("Kamola", "Saidova", 25);

var employee1 = new Employee("Aziz", "Karimov", 30, "johnny@gmail.com", 2_500);
var employee2 = new Employee("Sardor", "Aliyev", 28, "nimadur@gmail.com", 3_000);

var manager = new Manager("Dilshod", "Toshmatov", 40, "mrkafa@gmail.com", "qwerty123", new List<Employee> { employee1, employee2 });