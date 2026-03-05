

namespace AnimalPolimorphism
{
    // Base Animal class
    public class Animal
    {
        public virtual void FunFact()
        {
            Console.WriteLine("Hayvonlar haqida fun fact!");
        }
    }

    // dog clas
    public class Dog : Animal
    {
        public override void FunFact()
        {
            Console.WriteLine("Dog haqida fun fact!");
        }
    }

    // Cat
    public class Cat : Animal
    {
        public override void FunFact()
        {
            Console.WriteLine("Cats haqida fun fact!");
        }
    }

    // Elephant
    public class Elephant : Animal
    {
        public override void FunFact()
        {
            Console.WriteLine("Elephant haqida fun fact!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Animal Fun Fact Demo ===");

            // Create objects and store them in Animal type variables (Polimorphism)
            Animal animal1 = new Dog();
            Animal animal2 = new Cat();
            Animal animal3 = new Elephant();

            // Call FunFact method on each object
            Console.WriteLine("Calling FunFact() on all animals: \n");

            Console.WriteLine("Animal 1: ");
            animal1.FunFact();

            Console.WriteLine("Animal 2: ");
            animal2.FunFact();

            Console.WriteLine("Animal 3: ");
            animal3.FunFact();

            Console.WriteLine("\n" + new string('-', 60));
            Console.WriteLine("Polimorphism in action");
            Console.WriteLine(new string('-', 60));

            // Demonstrate polimorphism with an array
            Animal[] animals = new Animal[]
            {
                new Dog(),
                new Cat(),
                new Elephant(),
                new Cat(),
                new Dog()
            };

            Console.WriteLine($"\nProcessing {animals.Length} animals: \n");

            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] ");
                animals[i].FunFact();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}