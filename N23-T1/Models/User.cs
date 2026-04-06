namespace UserRegistrationApp.Models
{
    public class User
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }
    }
}