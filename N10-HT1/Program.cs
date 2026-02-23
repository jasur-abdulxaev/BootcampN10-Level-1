public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }
}

// Library management
public class LibraryManagement
{
    //key - book, value - nusxalar soni
    public Dictionary<Book, int> Books { get; set; } = new Dictionary<Book, int>();

    //kitob qo'shish
    public void AddBook(Book book, int copies)
    {
        if (copies < 0)
            throw new ArgumentOutOfRangeException("Nusxalar soni manfiy bo'lishi mumkun emas");

        Books[book] = copies;
    }

    //checkout - kitobni olib turish
    public bool Checkout(int bookId)
    {
        foreach (var entry in Books)
        {
            if (entry.Key.Id == bookId)
            {
                if (entry.Value > 0)
                {
                    Books[entry.Key] = entry.Value - 1;
                    Console.WriteLine($"\"{entry.Key.Title}\" kitob berildi. Qolgan nusxa: {Books[entry.Key]}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"\"{entry.Key.Title}\" kitobning nusxasi yoq!");
                    return false;
                }
            }
        }

        Console.WriteLine($"Id = {bookId} bo'lgan kitob topilmadi!");
        return false;
    }
}

class Programm
{
    static void Main()
    {
        Console.WriteLine("KUTUBXONA BOSHQARUVI!");

        // Book obyektlarini yaratish
        Book book1 = new Book(1, "Clean Code", "Robert S.Martin");
        Book book2 = new Book(2, "O'tkan kunlar", "Abdulla Qodiriy");
        Book book3 = new Book(3, "Algoritm va malumotlar tuzilmasi", "Thomas Cormen");

        //LibraryManagement obyekti
        LibraryManagement library = new LibraryManagement();

        //Kitob qo'shish
        library.AddBook(book1, copies: 3);
        library.AddBook(book2, copies: 1);
        library.AddBook(book3, copies: 0); // nusxa 0 ta

        Console.WriteLine("\nCHECKOUT");

        //nusxasi bor kitob -> true
        library.Checkout(bookId: 1);

        //nusxasi bor kitob -> true
        library.Checkout(bookId: 2);

        //nusxasi endi tugagan kitob -> false
        library.Checkout(bookId: 2);

        //nusxasi 0 ta kitob -> false
        library.Checkout(bookId: 3);

        //mavjud bo'lmaagn kitob -> false
        library.Checkout(bookId: 99);
    }
}

