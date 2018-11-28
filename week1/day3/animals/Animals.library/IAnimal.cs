namespace Animals.library 
{
    public interface IAnimal {
        // an interface is a contract that a lass has to follow
        // specifying some methods it needs to have, with their argument types and return type.

        // no implementation
        // no data either
        // just method names, arguments, and return type.

        //(no backing filed or auto-implementation)
        // you
        string name {get;set;}

        void MakeSound();

        void GoTo (string location);
    }
}