using N14_HT2_CL;

namespace N14_HT2_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("║   SINF DAVOMATI TIZIMI - ULTIMATE        ║");
            Console.WriteLine();

            // UltimateClassroomAttendance sinfidan object yaratish
            UltimateClassroomAttendance attendance = new UltimateClassroomAttendance();

            // 5 ta o'quvchi qo'shish
            attendance.Mark("Ali Valiyev", true);
            attendance.Mark("Sara Karimova", false, "Kasallik");
            attendance.Mark("Omarbek Tursunov", true, "10 daqiqa kechikdi");
            attendance.Mark("Nodirbek Qodirov", false, "Oilaviy sabab");
            attendance.Mark("Dilshodbek Yuldashev", true);

            Console.WriteLine();

            // Davomatni chiqarish
            attendance.Display();

            Console.WriteLine("\nDastur tugadi.");
            Console.ReadKey();
        }
    }
}