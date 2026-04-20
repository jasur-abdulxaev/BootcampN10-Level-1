// Shart bu true yoki false qaytaradigan ifoda.
int age = 20;
bool isAdult = age >= 18; // Shart: age 18 yoki undan katta bo'lishi kerak

Console.WriteLine($"U voyaga yetganmi: {isAdult}");

//Bool mantiqiy turi. (true - false)
bool isRaining = false; //yomg'ir yog'mayapti
bool isActive = true;   // faol(darsga kelgan)

Console.WriteLine($"Bugun yomg'irli kunmi: {isRaining}");
Console.WriteLine($"Jasur bugun darsga keldimi: {isActive}");

// Shart operatorlari: ==, !=, >, <, >=, <=
int x = 10, y = 20;
Console.WriteLine(x < y); // true, chunki 10 kichik 20 dan
Console.WriteLine(x == y);// false, chunki 10 teng emas 20 ga

// If-else shart operatori
int yosh = 23;
if (yosh > 18)
{
    Console.WriteLine("20 yoshdan katta!");
}

// Ternary operator (shartli ifoda)
// Shart ? true bo'lsa : false bo'lsa

string result = yosh > 18 ? "20 yoshdan katta!" : "20 yoshdan kichik!";
Console.WriteLine(result);



