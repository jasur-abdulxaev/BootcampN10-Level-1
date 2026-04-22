namespace N52_HT1.Models;

public class MessageConstants
{
    public static class User
    {
        public const string NotFound = "User topilmadi.";
        public const string AlreadyExists = "Bu email allaqachon ro'yxatdan o'tgan.";
        public const string Created = "User muvaffaqiyatli qo'shildi.";
        public const string Updated = "User muvaffaqiyatli yangilandi.";
        public const string Deleted = "User muvaffaqiyatli o'chirildi.";
    }

    public static class Email
    {
        public const string WelcomeSubject = "Xush kelibsiz!";
        public static string WelcomeBody(string firstname) =>
            $"Assalomu alaykum, {firstname}! Tizimga muvaffaqqiyatli ro'yhatdan o'tdingiz.";
    }
}
