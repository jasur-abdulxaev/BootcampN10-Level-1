namespace N15_HT1
{
    // Validatsiya bilan ob-havo service
    // Takroriy sanalar uchun ma'lumotni yangilaydi
    public class ValidatedWeatherReport : WeatherReport
    {
        // Override qilingan Add method - validatsiya bilan
        public override void Add(DateTime date, string weather)
        {
            DateTime dateOnly = date.Date;

            // Mavjudligini tekshirish
            bool exists = false;
            foreach (var key in _weatherData.Keys)
            {
                if (key.Date == dateOnly)
                {
                    exists = true;
                    // Mavjud bo'lsa yangilash
                    _weatherData[key] = weather;
                    Console.WriteLine($" {dateOnly:yyyy-MM-dd} uchun ob-havo yangilandi: {weather}");
                    break;
                }
            }

            // Mavjud bo'lmasa, yangi ma'lumot qo'shish
            if (!exists)
            {
                _weatherData[dateOnly] = weather;
                Console.WriteLine($" {dateOnly:yyyy-MM-dd} uchun ob-havo qo'shildi: {weather}");
            }
        }
    }
}
