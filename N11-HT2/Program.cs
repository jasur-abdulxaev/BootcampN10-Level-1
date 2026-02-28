// Model
public sealed record Track(string Name, string Author)
{
    public override string ToString() => $"{Author} - {Name}";
}

// Service
class MusicPlayer
{
    private readonly List<Track> _tracks;
    private int _currentIndex;
    private bool _isPlaying;

    public Track? CurrentTrack => _tracks.Count > 0 ? _tracks[_currentIndex] : null;
    public bool IsPlaying => _isPlaying;

    public MusicPlayer()
    {
        _tracks = new List<Track>
        {
            new Track("Lose Yourself", "Eminem"),
            new Track("Ordinary", "Alex Warren"),
            new Track("How to love again?", "Billie Eilish"),
            new Track("Blinding Lights", "The Weeknd")
        };
        _currentIndex = 0;
        _isPlaying = false;
    }

    public string Next()
    {
        if (_tracks.Count == 0) return "Kollektsiya bo'sh";

        bool wasAtEnd = _currentIndex == _tracks.Count - 1;
        _currentIndex = (_currentIndex + 1) % _tracks.Count;
        _isPlaying = true;

        return wasAtEnd
            ? $"End of tracks, playing the first song - {CurrentTrack}"
            : $"Playing - {CurrentTrack}";
    }

    public string Previous()
    {
        if (_tracks.Count == 0) return "Kollektsiya bo'sh";

        bool wasAtStart = _currentIndex == 0;
        _currentIndex = (_currentIndex - 1 + _tracks.Count) % _tracks.Count;
        _isPlaying = true;

        return wasAtStart
            ? $"Beginning of tracks, playing the last song - {CurrentTrack}"
            : $"Playing - {CurrentTrack}";
    }

    public string Pause()
    {
        if (_tracks.Count == 0) return "Kollektsiya bo'sh";
        if (!IsPlaying) return "Allaqachon pauzada";

        _isPlaying = false;
        return $"Paused - {CurrentTrack}";
    }

    public string Play()
    {
        if (_tracks.Count == 0) return "Kollektsiya bo'sh";
        if (_isPlaying) return $"Allaqachon ijro etilmoqda - {CurrentTrack}";

        _isPlaying = true;
        return $"Playing - {CurrentTrack}";
    }
}

//UI
class Program
{
    static void Main(string[] args)
    {
        MusicPlayer player = new MusicPlayer();
        Console.WriteLine(player.Play());

        while (true)
        {
            Console.WriteLine();
            Console.Write("Choose the command (next - n, previous - p, pause - pause, play - play, quit - q): ");
            string command = Console.ReadLine()?.Trim().ToLower() ?? "";

            string result = command switch
            {
                "n" or "next" => player.Next(),
                "p" or "previous" => player.Previous(),
                "pause" => player.Pause(),
                "play" => player.Play(),
                "q" or "quit" => "Dastur tugatildi.",
                _ => "Noto'g'ri buyruq! Qaytadan urinib ko'ring."
            };

            Console.WriteLine(result);

            if (command is "q" or "quit") return;
        }
    }
}