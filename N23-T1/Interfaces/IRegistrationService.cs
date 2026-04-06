namespace UserRegistrationApp.Interfaces
{
    public interface IRegistrationService
    {
        void Register(string email, string password);
        bool Login(string email, string password);
    }
}