using N52_HT1.Data.DataAcces;
using N52_HT1.Events;
using N52_HT1.Services;
using N52_HT1.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Data
builder.Services.AddSingleton<IDataContext, AppFileContext>();

// Events — Singleton bo'lishi shart, aks holda subscribe/raise turli instance da bo'ladi
builder.Services.AddSingleton<AccountEventStore>();

// Services
builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();
builder.Services.AddScoped<IUserFoundationService, UserFoundationService>();
builder.Services.AddScoped<IAccountNotificationService, AccountNotificationService>();
builder.Services.AddScoped<IAccountService, AccountService>();

var app = builder.Build();

// AccountNotificationService ni startup da subscribe qildirish
// Scoped service ni manually resolve qilamiz
using (var scope = app.Services.CreateScope())
{
    var notificationService = scope.ServiceProvider
        .GetRequiredService<IAccountNotificationService>();

    notificationService.Subscribe();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();