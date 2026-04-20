public class DebitCard
{
    public string CardNumber { get; set; }
    public decimal Balance { get; set; }

    public DebitCard(string cardNumber, decimal balance)
    {
        CardNumber = cardNumber;
        Balance = balance;
    }

    public override string ToString()
        => $"Card: **** {CardNumber[^4..]} | Balance: ${Balance}";
}