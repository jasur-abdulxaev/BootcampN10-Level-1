
using N41_HT2.Models;
using N41_HT2.Services;

var user1 = new User("G'ishmat", "Toshmatov", "jasurabdulxaev@gmail.com");
var user2 = new User("Kamola", "Xoliqulova", "abdulkhaevjasur@gmail.com");

var template1 = new EmailTemplate(user1, Constants.WelcomeSubject, Constants.WelcomeBody);
var templte2 = new EmailTemplate(user2, Constants.WelcomeSubject, Constants.WelcomeBody);

var emailSenderService = new EmailSenderService();

var tasks = new List<Task>
{
    new (()=> emailSenderService.SendEmailAsync(template1)),
    new (()=> emailSenderService.SendEmailAsync(templte2)),
};

Parallel.ForEach(tasks, task => task.Start());
await Task.WhenAll(tasks);