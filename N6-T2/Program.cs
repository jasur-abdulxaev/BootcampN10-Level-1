string[] names = new string[]
{
    "Jasurbek", "A'zam", "Sultonbek", "Firdavs", "Abdurahmon",
    "Azizbek", "Mirzohid", "John", "Doe", "Ilhom"
};

int[] scores = new int[]
{
    98, 90, 75, 40, 23,
    83, 66, 55, 100, 44
};

// Sortlash jarayoni
for (int i = 0; i < scores.Length - 1; i++)
{
    for (int j = 0; j < names.Length - 1; j++)
    {
        if (scores[j] < scores[j + 1])
        {
            //scoreni almashtirish
            int tempScore = scores[j];
            scores[j] = scores[j + 1];
            scores[j + 1] = tempScore;

            //namesni ham mos ravishda almashtirib ketamiz
            string tempName = names[j];
            names[j] = names[j + 1];
            names[j + 1] = tempName;
        }
    }
}

Console.WriteLine("Natijalarni ko'rish (sortlangan holatda): ");

for (int i = 0; i < scores.Length; i++)
{
    Console.WriteLine((i + 1) + "." + names[i] + " " + scores[i]);
}