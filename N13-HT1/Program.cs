

using AnimalHierarchy;

namespace AnimalHierarchy
{
    // Base Animal class
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound.");
        }
    }

    // Bird class inheriting from Animal
    public class Bird : Animal
    {
        public void Fly()
        {
            Console.WriteLine("Bird is flying.");
        }
    }

    // Mammal class inheriting from Animal
    public class Mammal : Animal
    {
        public void Run()
        {
            Console.WriteLine("Mammal is running.");
        }
    }

    // Fish class inheriting from Animal
    public class Fish : Animal
    {
        public void Swim()
        {
            Console.WriteLine("Fish is swimming.");
        }
    }

    // Sparrow class inheriting from Bird
    public class Sparrow : Bird
    {
        // Sparrow can use all Bird methods including Fly()
    }

    // Tiger class inheriting from Mammal
    public class Tiger : Mammal
    {
        // Tiger can use all Mammal methods including Run()
    }

    // GreatWhiteShark class inheriting from Fish
    public class GreatWhiteShark : Fish
    {
        // GreatWhiteShark can use all Fish methods including Swim()
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Animal Hierarchay Demo ---");

        //Create Sparrow object and call its unique method
        Console.WriteLine("Sparrow: ");
        Sparrow sparrow = new Sparrow();
        sparrow.Fly();
        sparrow.MakeSound(); // Inherited from Animal

        Console.WriteLine();

        //Create Tiger object and call its unique method
        Console.WriteLine("Tiger: ");
        Tiger tiger = new Tiger();
        tiger.Run();
        tiger.MakeSound(); // Inherited from Animal

        Console.WriteLine();

        // Create GreatWhiteShark object and call its unique method
        Console.WriteLine("Great White Shark: ");
        GreatWhiteShark shark = new GreatWhiteShark();
        shark.Swim();
        shark.MakeSound(); // Inherited from Animal

        Console.WriteLine("\nPress nay key to exit...");
        Console.ReadKey();
    }
}