using UserRegistrationApp.Models;

namespace UserRegistrationApp.Validators
{
    public class UserValidator
    {
        public bool Validate(User user, out string error)
        {
            if (string.IsNullOrWhiteSpace(user.EmailAddress) || !user.EmailAddress.Contains("@"))
            {
                error = "Email noto‘g‘ri";
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 3)
            {
                error = "Password kamida 3 ta belgidan iborat bo‘lishi kerak";
                return false;
            }

            error = string.Empty;
            return true;
        }
    }
}