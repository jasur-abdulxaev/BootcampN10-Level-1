using System.Diagnostics;

while (true)
{
    Console.Clear(); // Menyu har safar toza chiqishi uchun
    Console.WriteLine("1. Content download");
    Console.WriteLine("2. File translate");
    Console.WriteLine("3. Exit");
    Console.Write("\nBuyruqni tanlang: ");

    var res = Console.ReadLine();

    if (res == "3") break;

    switch (res)
    {
        case "1":
            Console.Write("Video linkini kiriting: ");
            var url = Console.ReadLine();
            if (!string.IsNullOrEmpty(url))
            {
                Console.WriteLine("Video yuklanishni boshladi...");
                await DownloadVideoAsync(url);
            }
            break;

        case "2":
            Console.Write("Text kiriting: ");
            var text = Console.ReadLine();
            if (!string.IsNullOrEmpty(text))
            {
                TranslateAsync(text);
                Console.WriteLine("Brauzerda tarjima ochildi.");
            }
            break;

        default:
            Console.WriteLine("Nomalum buyruq! Qaytadan urinib ko'ring.");
            Thread.Sleep(1500);
            break;
    }
}

async Task DownloadVideoAsync(string url)
{
    // Fayl yo'lini xavfsizroq qilish (Dastur turgan joyda Downloads papkasi)
    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads");

    if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

    using (var httpClient = new HttpClient())
    {
        try
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var videoData = await httpClient.GetByteArrayAsync(url);

            // Faylga tasodifiy nom berish
            string fileName = $"{Guid.NewGuid().ToString().Substring(0, 10)}.mp4";
            string fullPath = Path.Combine(path, fileName);

            await File.WriteAllBytesAsync(fullPath, videoData);

            stopWatch.Stop();
            Console.WriteLine($"\n[Muvaffaqiyatli] Video yuklandi!");
            Console.WriteLine($"Fayl nomi: {fileName}");
            Console.WriteLine($"Ketgan vaqt: {stopWatch.Elapsed.Seconds} soniya");
            Console.WriteLine("\nDavom etish uchun ixtiyoriy tugmani bosing...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nXato yuz berdi: {ex.Message}");
            Console.ReadKey();
        }
    }
}

void TranslateAsync(string text)
{
    // Text ichidagi bo'shliqlarni URL formatiga o'tkazish (masalan: "salom dunyo" -> "salom%20dunyo")
    string encodedText = Uri.EscapeDataString(text);
    string url = $"https://translate.google.com/?hl=uz&sl=en&tl=uz&text={encodedText}&op=translate";

    // Brauzerni ochish
    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
}