namespace N15_HT1
{
    // ob-havo malumotlarini boshqaruvchi asosiy service
    public class WeatherReport
    {
        protected Dictionary<DateTime, string> _weatherData;

        public WeatherReport()
        {
            _weatherData = new Dictionary<DateTime, string>();
        }

        // Ob-havo malumotlarini qo'shish
        public virtual void Add(DateTime date, string weather)
        {
            _weatherData[date] = weather; // mavjud bo'lsa yangilash, yo'q bo'lsa qo'shish
        }

        // Berilgan sanaga ob-havo topish (private)
        private string Find(DateTime date)
        {
            // Faqat sanani solishtiramiz
            DateTime dateOnly = date.Date;

            foreach (var item in _weatherData)
            {
                if (item.Key.Date == dateOnly)
                {
                    return item.Value; // Agar topilsa, ob-havo qaytaradi
                }
            }

            return null; // Agar topilmasa, null qaytaradi
        }

        // Berilgan sanaga ob-havoni olish
        public virtual string Get(DateTime date)
        {
            string weather = Find(date);

            if (weather == null)
            {
                return $"Ob-havo malumoti topilmadi: {date.ToShortDateString()}";
            }

            return weather;
        }
    }
}
