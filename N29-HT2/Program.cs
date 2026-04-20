using N29_HT2.Models;
using N29_HT2.Services;

var e1 = new Employee("Jasurbek", "Abdulkhaev", "jasurabdulxaev@gmail.com");
var service = new EmployeeService();
await service.HireAsync(e1);