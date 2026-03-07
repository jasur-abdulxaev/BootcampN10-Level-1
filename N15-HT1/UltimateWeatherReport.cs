namespace N15_HT1
{
    // Kengaytirilgan ob-havo service
    // Bir necha kunlik prognoz bilan
    public class UltimateWeatherReport : ValidatedWeatherReport
    {
        // Private tartiblash metodi
        private List<KeyValuePair<DateTime, string>> Sort(List<KeyValuePair<DateTime, string>> data)
        {
            // O'sib borish tartibi bo'yicha
            return data.OrderBy(x => x.Key).ToList();
        }

        // Berilgan sanadan boshlab n kun uchun ob-havo
        public List<string> Get(DateTime startDate, int daysCount)
        {
            List<KeyValuePair<DateTime, string>> result = new List<KeyValuePair<DateTime, string>>();
            DateTime dateOnly = startDate.Date;

            // N kun uchun ma'lumotlarni yig'ish
            for (int i = 0; i < daysCount; i++)
            {
                DateTime currentDate = dateOnly.AddDays(i);

                // Shu sanani topish
                foreach (var item in _weatherData)
                {
                    if (item.Key.Date == currentDate)
                    {
                        result.Add(new KeyValuePair<DateTime, string>(currentDate, item.Value));
                        break;
                    }
                }
            }

            // To'liq ma'lumot borligini tekshirish
            if (result.Count < daysCount)
            {
                Console.WriteLine("Uzur to'liq malumot yo'q");
                return new List<string>();
            }

            // Tartiblash va faqat ob-havoni qaytarish
            var sortedResult = Sort(result);
            List<string> weatherList = new List<string>();

            foreach (var item in sortedResult)
            {
                weatherList.Add($"{item.Key:yyyy-MM-dd}: {item.Value}");
            }

            return weatherList;
        }

        // Bugundan boshlab N kun uchun ob-havo
        public List<string> Get(int daysCount)
        {
            return Get(DateTime.Now, daysCount);
        }
    }
}
