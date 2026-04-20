namespace N37_HT1.Models;

public class EmailMessage
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public string SenderAddress { get; set; }
    public string ReceiverAddress { get; set; }

    public EmailMessage(string subject, string body, string senderAddress, string receiverAddress)
    {
        Subject = subject;
        Body = body;
        SenderAddress = senderAddress;
        ReceiverAddress = receiverAddress;
    }
}
