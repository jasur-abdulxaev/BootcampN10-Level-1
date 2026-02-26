
namespace MovieLibraryApp
{
    // MODEL
    class Movie
    {
        public string Name { get; set; }
        public string Genre { get; set; }          // janri formati
        public double ReviewScore { get; set; }    // 1 dan 10 gacha ball

        public Movie(string name, string genre, double reviewScore)
        {
            Name = name;
            Genre = genre;
            ReviewScore = reviewScore;
        }

        public override string ToString()
        {
            return $"Movie name: {Name}, Genre: {Genre}, Review Score: {ReviewScore}";
        }
    }

    // LIBRARY SERVICE
    class MovieLibrary
    {
        private List<Movie> _movies = new List<Movie>();

        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }

        // Hamma filmlarni qaytarish
        public List<Movie> Display()
        {
            return _movies;
        }

        // Filmlarni ismi bo'yicha qidirish
        public List<Movie> SearchByName(string name)
        {
            return _movies
                .Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Filmlarni janr bo'yicha qidirish
        public List<Movie> SearchByGenre(string genre)
        {
            return _movies
                .Where(g => g.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        //filmlarni ganreni x dan yuqorilarini qidirish
        public List<Movie> SearchByScoreHigherThan(double score)
        {
            return _movies
                .Where(m => m.ReviewScore > score)
                .OrderByDescending(m => m.ReviewScore)
                .ToList();
        }
    }

    class Program
    {
        static void PrintMovies(List<Movie> movies, string message)
        {
            if (movies.Count == 0)
            {
                Console.WriteLine(" Hech narsa topilmadi!");
                return;
            }

            Console.WriteLine($"\n === {message} ({movies.Count} ta) ===\n");
            foreach (Movie movie in movies)
            {
                Console.WriteLine($" -{movie}");
            }
        }

        static void Main(string[] args)
        {
            MovieLibrary library = new MovieLibrary();

            // 10 ta film qo'shamiz
            library.Add(new Movie("The Dark Knight", "Action, Crime, Drama", 9.0));
            library.Add(new Movie("Inception", "Action, Adventure, Sci-Fi", 8.8));
            library.Add(new Movie("The Conjuring", "Horror, Mystery, Thriller", 7.5));
            library.Add(new Movie("Toy Story", "Animation, Adventure, Comedy", 8.3));
            library.Add(new Movie("The Hangover", "Comedy", 7.7));
            library.Add(new Movie("Interstellar", "Adventure, Drama, Sci-Fi", 8.7));
            library.Add(new Movie("G'ishtmatning sarguzashtlari", "Fantasy, Comedy, Adventure", 3.0));
            library.Add(new Movie("Shawshank Redemption", "Drama", 9.3));
            library.Add(new Movie("Spider-Man: No Way Home", "Action, Adventure, Sci-Fi", 8.2));
            library.Add(new Movie("Frozen", "Animation, Adventure, Comedy", 7.4));

            Console.WriteLine("\n   MOVIE LIBRARY DASTURI!  \n");

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n Choose a command (display all - d / search by name - sn " +
                    "/ search by genre - sg / search by review - sr / exit - e )");

                Console.Write(" >>> ");
                string command = Console.ReadLine()?.Trim().ToLower();

                switch (command)
                {
                    case "d":
                        List<Movie> allMovies = library.Display();
                        PrintMovies(allMovies, "Barcha Filmlar");
                        break;

                    case "sn":
                        Console.Write(" Enter film name: ");
                        string nameQuery = Console.ReadLine()?.Trim().ToLower();

                        if (string.IsNullOrEmpty(nameQuery))
                        {
                            Console.WriteLine(" Iltimos film nomini kiriting!");
                            break;
                        }

                        List<Movie> nameResults = library.SearchByName(nameQuery);
                        PrintMovies(nameResults, $"\"{nameQuery}\" bo'yicha topilgan filmlar");
                        break;

                    case "sg":
                        Console.Write("  Enter genre: ");
                        string genreQuery = Console.ReadLine()?.Trim();

                        if (string.IsNullOrEmpty(genreQuery))
                        {
                            Console.WriteLine("  Iltimos, janrni kiriting!");
                            break;
                        }

                        List<Movie> genreResults = library.SearchByGenre(genreQuery);
                        PrintMovies(genreResults, $"\"{genreQuery}\" janridagi filmlar");
                        break;

                    case "sr":
                        double score;
                        while (true)
                        {
                            Console.Write(" Enter a score:  ");
                            string input = Console.ReadLine()?.Trim();

                            if (double.TryParse(input, out score) && score >= 1 && score <= 10)
                                break;

                            Console.WriteLine(" Invalid score, enter between 1 and 10");
                        }

                        List<Movie> scoreResults = library.SearchByScoreHigherThan(score);
                        PrintMovies(scoreResults, $"Bali {score} dan yuqori filmlar");
                        break;

                    case "e":
                        Console.WriteLine("\n   Dasturdan chiqildi. Xayr!");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine(" Notori buyruq!");
                        break;
                }
            }
        }
    }
}