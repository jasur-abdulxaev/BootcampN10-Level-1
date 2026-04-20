using N37_HT1.Enums;
using N37_HT1.Models;
using N37_HT1.Services;

var userService = new UserService();
var emailTemplateService = new EmailTemplateService();
var emailSenderService = new EmailSenderService();
var emailService = new EmailService(emailSenderService);
var notificationService = new NotificationManagementService(
    userService,
    emailService,
    emailTemplateService
// emailSenderService — olib tashlandi!
);

var users = new List<User>
{
    new User("Eldor",  "Abduholiqov", "eldorabdukhalikov90@gmail.com", Status.Active),
    new User("Davron", "Umrzoqov",    "davronbekumrzoqov6@gmail.com",  Status.Registered),
    new User("Jasur",  "Abdulhayev",  "jasurabdulxaev@gmail.com",      Status.Active)
};

var templates = new List<EmailTemplate>
{
    new EmailTemplate("First subject",  "First subject's body"),
    new EmailTemplate("Second subject", "Second subject's body"),
};


// ← ANA SHU KERAK EDI
await notificationService.NotifyUsers();

//using N37_HT1.Services;
//using N37_HT1.Models;
//using N37_HT1.Enums;

//var userService = new UserService();
//var emailService = new EmailService();
//var emailTemplateService = new EmailTemplateService();
//var emailSenderService = new EmailSenderService();

//var notificationService = new NotificationManagementService(userService, emailService, emailTemplateService, emailSenderService);

//userService.users.Add(new User("Abdura", "Abdura", "abdura52.uz@gmail.com", Status.Deleted));
//userService.users.Add(new User("Habiba", "Sattorova", "sattorovahabiba00@gmail.com", Status.Registered));
//await notificationService.NotifyUsers();
