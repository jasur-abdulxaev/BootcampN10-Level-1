namespace N14_HT2_CL
{
    // Kengaytirilgan davomad service - sabab bilan
    public class UltimateClassroomAttendance : ClassroomAttendance
    {
        // Method overload - sabab bilan belgilash
        public void Mark(string fullName, bool isPresent, string cause = "")
        {
            // Satatus create qilish
            string status;

            if (isPresent)
            {
                status = "present";
                // Agar sabab bo'lsa qo'shish (masalan, kechikib kelgan)
                if (!string.IsNullOrEmpty(cause))
                {
                    status += $" ({cause})";
                }
            }
            else
            {
                status = "absent";
                // Kelmagan bo'lsa, sababni qo'shish (masalan, kasal)
                if (!string.IsNullOrEmpty(cause))
                {
                    status += $" -{cause}";
                }
            }

            // Dictionaryga qo'shish
            if (_students.ContainsKey(fullName))
            {
                _students[fullName] = status; // mavjud bo'lsa, yangilash
            }
            else
            {
                _students.Add(fullName, status); // yangi o'quvchi qo'shish
            }
        }

        // Override qilingan Display method - statistika bilan
        public override void Display()
        {
            // Parent class ning Display method ni chaqirish
            base.Display();

            // Qo'shimcha statistika chiqarish
            Console.WriteLine();
            Console.WriteLine("=== Statistike ===");

            double attendance = GetStats();
            Console.WriteLine($"Qatnashganlik foizi: {attendance:F2}%");

            int totalStudents = _students.Count;
            int presentStudents = (int)Math.Round(totalStudents * attendance / 100);
            int absentStudents = totalStudents - presentStudents;

            Console.WriteLine($"Jami: {totalStudents} ta o'quvchi");
            Console.WriteLine($"Kelganlar: {presentStudents} ta");
            Console.WriteLine($"Kelmaganlar: {absentStudents} ta");
        }
    }
}
