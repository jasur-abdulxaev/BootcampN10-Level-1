public class PaymentService : IPaymentService
{
    public bool Checkout(decimal amount, DebitCard debitCard)
    {
        if (debitCard.Balance >= amount)
        {
            debitCard.Balance -= amount;
            Console.WriteLine($"  ✅ To'lov amalga oshdi: -${amount} | Qoldiq: ${debitCard.Balance}");
            return true;
        }

        Console.WriteLine($"  ❌ Kartada yetarli pul yo'q! Kerak: ${amount} | Mavjud: ${debitCard.Balance}");
        return false;
    }
}