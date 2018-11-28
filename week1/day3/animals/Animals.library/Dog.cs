using System;
 namespace Animals.library {
    public class Dog : IAnimal{
        // not fields - properties

        //
        public string Name {
            get {
                return "Bob";
            }
            set {
                Console.WriteLine("inside property field");
            }
         }
         // auto-property

        private string _breed; 
        public string Breed { 
            
            get {
                return _breed;
            }
            set {
                if (value !=null && value != "") {
                    _breed = value;
                }
            }
        }
         // property (with explicit backing field)
        private int _age;
        public int Age {
            get {
                return _age;
            }
            set {
                _age = value;
                // keyword "value" in a setter takes in the assigned value
            }
        }

        public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // classic getters and setters
        private int Weight;
         public int GetWeight () {
            return Weight;
        }
         public void SetWeight (int weight) {
            Weight = weight;
        }
         public void Bark()
        {
            Console.WriteLine("Woof");
        }

        public void MakeSound()
        {
            Bark();
        }

        public void GoTo(string location)
        {
            // string interpolation syntax "syntax sugar"
            // prefix with $
            // inside {} you should give an expression
            // .......either string or nay other object that ToString will be called on

            string output = $"Walking to {location}";
            Console.WriteLine(output);
        }
        // snippets: prop, propfull
    }
}