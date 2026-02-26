
//MODEL
public class Document
{
    public string Content { get; set; }

    public Document(string content)
    {
        Content = content;
    }
}

//SERVICE
public class DocumentAnalyzer
{
    private const int startScore = 100;

    public int Analyze(Document document)
    {
        int score = startScore;
        string content = document.Content;

        //Gaplarni ajratish
        string[] sentences = SplitSentences(content);

        //Barcha so'zlarni yig'ish
        List<string> allWords = new List<string>();
        foreach (string sentence in sentences)
        {
            List<string> words = ExtractWords(sentence);
            foreach (string word in words)
                allWords.Add(word);
        }

        // So'zlar soni 500 tadan kamligini tekshiramiz
        if (allWords.Count < 500)
        {
            score -= 5;
            Console.WriteLine($"[-5] So'zlar soni: {allWords.Count} (500 dan kam)");
        }

        // Biron so'z 20% dan ko'p takrorlansa
        Dictionary<string, int> frequency = new Dictionary<string, int>();
        foreach (string word in allWords)
        {
            string lower = word.ToLower();
            if (frequency.ContainsKey(lower))
                frequency[lower]++;
            else frequency[lower] = 1;
        }

        foreach (KeyValuePair<string, int> pair in frequency)
        {
            double percent = (double)pair.Value / allWords.Count * 100;
            if (percent > 20)
            {
                score -= 5;
                Console.WriteLine($"[-5] '{pair.Key}' so'zi {percent:F1}% ni tashkil qiladi (>20%)");
            }
        }

        // har bir gapni tekshirish
        foreach (string sentence in sentences)
        {
            List<string> words = ExtractWords(sentence);
            if (words.Count == 0) continue;

            //Birinchi so'z kapital bolmasa
            if (!char.IsUpper(words[0][0]))
            {
                score -= 5;
                Console.WriteLine($"[-5] Birinchi so'z capital emas -> '{words[0]}'");
            }

            //2-xarfdan boshlab qolghan harflar kichikligini tekshirish
            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];

                // Faqat kichik harflar bolsa
                if (!IsAllLower(word))
                {
                    score -= 10;
                    Console.WriteLine($"[-10] Kichik harfda yozilgan so'z uchun -> '{word}'");
                }

                //So'z uzunligi 20 dan oshsa
                if (word.Length > 20)
                {
                    score -= 20;
                    Console.WriteLine($"[-20] So'z uzunligi 20 dan oshib ketdi -> '{word}'");
                }
            }
        }

        return score;
    }

    //Gaplarni ajratish
    private string[] SplitSentences(string content)
    {
        List<string> sentences = new List<string>();
        string current = "";

        for (int i = 0; i < content.Length; i++)
        {
            char c = content[i];
            current += c;

            if (c == '.' || c == '?' || c == '!')
            {
                sentences.Add(current.Trim());
                current = "";
            }
        }

        if (current.Trim() != "")
            sentences.Add(current.Trim());

        return sentences.ToArray();
    }

    //So'zlarni ajratib olish
    private List<string> ExtractWords(string sentence)
    {
        List<string> words = new List<string>();
        string word = "";

        foreach (char c in sentence)
        {
            if (char.IsLetter(c))
            {
                word += c;
            }
            else
            {
                if (word != "")
                {
                    words.Add(word);
                    word = "";
                }
            }
        }

        if (word != "")
            words.Add(word);

        return words;
    }

    //So'z faqat kichik xarflardan iboratmi?
    private bool IsAllLower(string word)
    {
        foreach (char c in word)
        {
            if (!char.IsLower(c))
                return false;
        }

        return true;
    }
}

// MAIN
class Programm
{
    static void Main()
    {
        string essay = "Lorem ipsum dolor sit amet consectetur adipisicing elit. " +
                       "quaerat est quas commodi quibusdam labore, nihil doloribus quam " +
                       "temporibus inventore optio expedita consectetur voluptatem QUIDEM " +
                       "nulla soluta earum. Numquam rem alias minima culpa iste distinctio. " +
                       "Eum similique est consequuntur minus, odio nisi recusandae iure " +
                       "asperiores facere, reiciendis voluptate maiores! Repellat, dolorum!";

        var document = new Document(essay);
        var analyzer = new DocumentAnalyzer();

        Console.WriteLine("ANALIZ BOSHLANDI!");
        int result = analyzer.Analyze(document);
        Console.WriteLine($"YAKUNIY BALL: {result}");
    }
}