using System;

namespace Animals.library {
    public abstract class ABird: IAnimal {
        // abstract class cannot be instantiated, but can provide implementation
        // to be shared by subclasses

        public void GoTo(string location)  {
            Console.WriteLine($"Flying to {location}");
        }
    }
}