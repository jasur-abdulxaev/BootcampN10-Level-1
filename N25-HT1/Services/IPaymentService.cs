public interface IPaymentService
{
    // Kartada yetarli pul bo'lsa yechib true, bo'lmasa false qaytaradi
    bool Checkout(decimal amount, DebitCard debitCard);
}