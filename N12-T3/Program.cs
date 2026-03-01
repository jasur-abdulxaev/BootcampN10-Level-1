HashSet<string> hackathon1 = new HashSet<string> { "John", "Jasur", "Karim" };
HashSet<string> hackathon2 = new HashSet<string> { "Karim", "John", "Jasur" };

bool isEqual = hackathon1.SetEquals(hackathon2);

Console.WriteLine($"Bir xilmi hakaton qatnashchilari: {isEqual}");