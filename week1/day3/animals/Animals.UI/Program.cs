using System;
using Animals.library;

namespace Animals.UI
{
    class Program
    {
        // your entry point needs a static void Main(string[] args) method and that is where the execution starts

        // "Program.cs" and program class anme are just conventions

        //naming convention is C# - PascalCase aka TitleCase for
        // .... classes, methods, properties, namespaces
        // camelCase (first letter lowercase) for local variables
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            Console.WriteLine("Hello World!");

            //using fileds and properties

            //using getters and setters with prvate filed. no reason to do this

            dog.SetWeight(6);

            Console.WriteLine(dog.GetWeight());

            dog.Name = "Fido";
            dog.Breed = "pitbull";
            Console.WriteLine(dog.Name + " breed is: " + dog.Breed);

            dog.GoTo("the big park");

            
            IAnimal animal = new Dog();

            animal = new Eagle();

            // this is okay because both calsses are within/under the IAnimal type.
            // BUT - you're not allowed to do dog-specific or eagle-specific thing via this variable
            //... error: animal.Fly();

            Eagle e = (Eagle) animal();

            // these terms are interchangable
            //  - superclass, base, class, parent class
            //  - subclass, derived class, child class

            // good design (separation of concerns)
            // means you shouldn't write code needlessly tied to one specific implementation         
            
            // then you use the same code with multiple implementations of the calsses you're using

            DisplayData(new Dog());
            DisplayData(new Eagle());
        }

        public static void DisplayData(IAnimal animal) {
            Console.WriteLine(animal.Name);
        }
    }
}
