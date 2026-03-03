public enum Difficulty
{
    Easy,
    Standard,
    Hard
}

public interface IQuestionProvider
{
    bool TryGetQuestion(Difficulty difficulty, out string question, out string answer);
    bool HasQuestions(Difficulty difficulty);
}

public interface IDifficultyManager
{
    Difficulty Current { get; }
    void RegisterCorrect();
    void RegisterWrong();
}

public class QuestionProvider : IQuestionProvider
{
    private readonly Dictionary<Difficulty, Dictionary<string, string>> _pools = new()
    {
        [Difficulty.Standard] = new()
        {
            ["What is the capital city of Australia?"] = "Canberra",
            ["Which river is the longest in South America?"] = "Amazon",
            ["Which continent is known as the Land Down Under?"] = "Australia",
            ["In which continent is the Sahara Desert located?"] = "Africa",
            ["What is the highest mountain in the European Alps?"] = "Mont Blanc"
        },
        [Difficulty.Easy] = new()
        {
            ["Name the largest island in the world"] = "Greenland",
            ["What is the largest lake by surface area in Africa?"] = "Victoria",
            ["Name the smallest country in the world by land area."] = "Vatican"
        },
        [Difficulty.Hard] = new()
        {
            ["Which country is home to the world's largest coral reef system?"] = "Australia",
            ["What is the deepest oceanic trench in the world?"] = "Mariana",
            ["Name the active volcano that famously erupted in AD 79, burying Pompeii."] = "Mount Vesuvius"
        }
    };

    private readonly HashSet<string> _usedQuestions = new();
    private readonly Random _random = new();

    public bool HasQuestions(Difficulty difficulty)
    {
        return _pools[difficulty].Any(q => !_usedQuestions.Contains(q.Key));
    }

    public bool TryGetQuestion(Difficulty difficulty, out string question, out string answer)
    {
        var available = _pools[difficulty]
            .Where(q => !_usedQuestions.Contains(q.Key))
            .ToList();

        if (available.Count == 0)
        {
            question = "";
            answer = "";
            return false;
        }

        var selected = available[_random.Next(available.Count)];
        _usedQuestions.Add(selected.Key);

        question = selected.Key;
        answer = selected.Value;
        return true;
    }
}

public class DifficultyManager : IDifficultyManager
{
    private int _correctStreak;
    private int _wrongStreak;

    public Difficulty Current { get; private set; } = Difficulty.Standard;

    public void RegisterCorrect()
    {
        _correctStreak++;
        _wrongStreak = 0;
        Evaluate();
    }

    public void RegisterWrong()
    {
        _wrongStreak++;
        _correctStreak = 0;
        Evaluate();
    }

    private void Evaluate()
    {
        if (_wrongStreak >= 2)
        {
            Current = Difficulty.Easy;
            _wrongStreak = 0;
        }
        else if (_correctStreak >= 2)
        {
            Current = Difficulty.Hard;
            _correctStreak = 0;
        }
    }
}

public class QuizEngine
{
    private readonly IQuestionProvider _provider;
    private readonly IDifficultyManager _difficulty;

    private static readonly Difficulty[] Fallback =
    {
        Difficulty.Standard,
        Difficulty.Easy,
        Difficulty.Hard
    };

    public QuizEngine(IQuestionProvider provider, IDifficultyManager difficulty)
    {
        _provider = provider;
        _difficulty = difficulty;
    }

    public void Start()
    {
        while (TryAskQuestion()) { }
        Console.WriteLine("\nTest yakunlandi!");
    }

    private bool TryAskQuestion()
    {
        if (_provider.TryGetQuestion(_difficulty.Current, out var question, out var answer))
        {
            Ask(question, answer);
            return true;
        }

        foreach (var fallback in Fallback)
        {
            if (fallback == _difficulty.Current) continue;

            if (_provider.TryGetQuestion(fallback, out question, out answer))
            {
                Console.WriteLine($"\n[{_difficulty.Current} tugadi, {fallback} ga o'tildi]");
                Ask(question, answer);
                return true;
            }
        }

        return false;
    }

    private void Ask(string question, string answer)
    {
        Console.WriteLine($"\n[{_difficulty.Current.ToString().ToUpper()}] {question}");
        Console.Write("Javobingiz: ");
        string input = Console.ReadLine()?.Trim() ?? "";

        if (input.Equals(answer, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("To'g'ri!");
            _difficulty.RegisterCorrect();
        }
        else
        {
            Console.WriteLine($"Noto'g'ri! Javob: {answer}");
            _difficulty.RegisterWrong();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IQuestionProvider provider = new QuestionProvider();
        IDifficultyManager difficulty = new DifficultyManager();

        var quiz = new QuizEngine(provider, difficulty);
        quiz.Start();
    }
}