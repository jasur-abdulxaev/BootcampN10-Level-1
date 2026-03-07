
namespace N14_HT2_CL
{
    // oddiy sinf davomati uchun setvice
    public class ClassroomAttendance
    {
        // O'quvchilar va ularning holati (protected - faqat sinf ichida va merosxo'rlarda ko'rinadi)
        protected Dictionary<string, string> _students;

        public ClassroomAttendance()
        {
            _students = new Dictionary<string, string>();
        }

        // O'quvchilarni belgilash keldi kelmadi deb
        public void Mark(string fullName, bool isPresent)
        {
            // true/false ni present/absent ga o'zgartirish
            string status = isPresent ? "Present" : "Absent";

            // Dictionary ga qo'shish yoki yangilash
            if (_students.ContainsKey(fullName))
            {
                _students[fullName] = status; // mavjud bo'lsa, yangilash
            }
            else
            {
                _students.Add(fullName, status); // yangi o'quvchi qo'shish
            }
        }

        // Davomatni ekranga chiqarish
        public virtual void Display()
        {
            Console.WriteLine("=== Sinf Davomati ===");
            Console.WriteLine();

            if (_students.Count == 0)
            {
                Console.WriteLine("Hali hech kim belgilangan emas.");
                return;
            }

            int counter = 0;
            foreach (var student in _students)
            {
                Console.WriteLine($"{counter}. {student.Key} - {student.Value}");
                counter++;
            }
        }

        // Statatistika - necha foiz qatnashgan (internal protected - faqat shu assembly ichida va merosxo'rlarda ko'rinadi)
        internal protected double GetStats()
        {
            if (_students.Count == 0)
                return 0.0;

            int presentCount = 0;
            foreach (var student in _students)
            {
                if (student.Value.Contains("present"))
                    presentCount++;
            }

            // Foizni hisoblash
            double percentage = (double)presentCount / _students.Count * 100;
            return percentage;
        }
    }
}
