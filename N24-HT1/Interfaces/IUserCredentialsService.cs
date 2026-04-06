public interface IUserCredentialsService
{
    // Kuchli parolni tekshirib, credential qo'shadi
    UserCredentials Add(Guid userId, string password);

    // userId bo'yicha credential qaytaradi; topilmasa null
    UserCredentials? GetByUserId(Guid userId);
}