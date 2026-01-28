using System.Text;

Console.Write("Essay kiriting: ");
var essay = Console.ReadLine();

var mistakes = string.Empty;
var score = 100;

// So'zlarni va gaplarni alohida massivlarga bolib chiqdik.
var words = essay.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
var sentences = essay.Trim().Split('.', '!', '?');

// So'zlar sonini 500 tadan kam emasligini tekshiramiz.
if (words.Length < 500)
{
    mistakes += "\nSo'zlar soni 500 tadan kamligi uchun\n";
    score -= 5;
}

//So'zni takrorlanishini sanashimiz uchun.
foreach (var word in words)
{
    var count = (int)default;
    foreach (var w in words)
        if (w.Equals(word, StringComparison.OrdinalIgnoreCase))
            count++;
    if ((double)words.Length / 100 * count > 20)
    {
        mistakes += $"Essaydagi {word} so'zi umumiy matnning 20% qismidan ko'p!\n";
        score -= 5;
    }
}

//Gapning birinchi so'zi katta harf bilan boshlanishini tekshiramiz.
var scap = new StringBuilder();

foreach (var sentence in sentences)
{
    if (string.IsNullOrWhiteSpace(sentence)) continue;

    words = sentence.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var firstWord = words[0];

    //Birinchi harf katta emas yoki qolganlarini kichik emasligini tekshiramiz.
    bool isCapitalCorrect =
        char.IsUpper(firstWord[0]) && firstWord.Skip(1).All(char.IsLower);

    if (!isCapitalCorrect)
        scap.Append(firstWord).Append(',');
}

if (scap.Length > 0)
{
    mistakes += $"Capital bo'lmagan birinchi so'zlar {scap}\n";
    score -= 5;
}

// Birinchi so'zadan boshqa so'zlarni kichkinadan yozilganligiga tekshiradi.
var incorrectWords = new StringBuilder();

foreach (var sentence in sentences)
{
    //Bo'sh gaplar kelsa o'tkazib yuboradi.
    if (string.IsNullOrWhiteSpace(sentence)) continue;

    var wordsB = sentence
        .Trim()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    for (int i = 1; i < wordsB.Length; i++)
    {
        //So'zdagi belgilarni olib tashlayabmiz va xatoni oldi olinyabdi.
        var word = wordsB[i].Trim(new char[] { '.', ',', '!', '?' });

        //Bo'sh so'zlar kelsa o'tkazvoramiz.
        if (word.Length == 0) continue;

        //So'zimiz faqat kichik harf bo'lmasa.
        if (!word.All(char.IsLower))
            incorrectWords.Append(word).Append(",");
    }
}

if (incorrectWords.Length > 0)
    mistakes += $"Birinchi so'z bo'lmagan va faqat kichik harf bo'lmagan so'zlar {incorrectWords}\n";


var incorrectWordsB = new StringBuilder();


foreach (var word in words)
{
    //So'zni ozini tozalab olish.
    var cleanWord = word.Trim(new char[] { '.', ',', '!', '?', ';', ':' });

    if (cleanWord.Length > 20)
        incorrectWordsB.Append(cleanWord).Append(" ");
}

if (incorrectWordsB.Length > 0)
{
    mistakes += $"Uzunligi 20 dan oshib ketgan so'zlar {incorrectWordsB} \n";
    score -= 20;
}

Console.WriteLine(mistakes);
Console.WriteLine($"\nResult: {score} ball!");
