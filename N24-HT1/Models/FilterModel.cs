// Abstract base — barcha filter modellar shu ikki xususiyatni meros oladi
public abstract class FilterModel
{
    public int PageSize { get; set; } = 10;   // Sahifadagi elementlar soni
    public int PageToken { get; set; } = 0;    // Boshlanish indeksi (offset)
}