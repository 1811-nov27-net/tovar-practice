using System;

namespace ExceptionHandling1
{
    class Program
    {
        static void Main(string[] args)
        {
            // exceptios are runtime errors that we can potentially handle.
            // exception areobjects and defined by classes like anything else

            try
            {
                badCode();
                //try goes around code is expected to throw an exception
                var x = 4;
                var y = x / 0;
                Console.WriteLine("never prints because an exceptions was thrown first");
              
            }

            catch (DivideByZeroException e)
            {
                //handle the exception in catch block
                Console.WriteLine("divide by 0, moving on");
                //at the end of catch, we move on with business
            }

            catch (InvalidCastException ex)
            {
                Console.WriteLine("handled bad cast");

            }
            Console.WriteLine("the program continues");
        }

        static void badCode ()
        {
            object o = true;
            string s = (string) o;
        }
    }
}
