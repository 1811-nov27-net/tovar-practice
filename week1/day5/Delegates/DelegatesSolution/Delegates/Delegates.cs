using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    public class Delegates
    {
        static void Main(string[] args)
        {
            // object initialization syntax.
            // if no parens after MoviePlayer, zero-arg construcor "()" is assumed.

            var player = new MoviePlayer
            {
                CurrentMovie = "Lord of the Rings: The Fellowship of the Ring Extented Edition"
            };

            // subcribe to events with +=
            MoviePlayer.MovieFinishedHandler handler = EjectDisc;
            //  player.MovieFinished += handler;
            // unsubcribe with -=
            // player.MovieFinished -= handler;

            //action is for void-return functions
            // func is for non-void-return functions
            Action<string> handler2 = EjectDisc;

            // player.MovieFinished += handler2;

            // lambda expressions 
            player.PlayMovie();

            player.MovieFinished += s => Console.WriteLine("lambda subscribe");
            // this lambda takes in a string (ngerred by compiler)
            // and return nothing (becasue WriteLine by compiler)
            // therefore it is compatible with athat delegate type

            Func<int, string, bool> func = (num, str) => true;
            // the last type parameter is the return type,
            // and the ones before it iare the arguments.

            Func<bool> func2 = () => false;

            Action<int, string, bool> fun3 = (num, str, b) =>
            {
                if (b)
                {
                    Console.WriteLine(num);
                    Console.WriteLine(str);
                }
            };

            // lambdas can have a bock body like methods

            // function taking bool, returning void


        }

        static void EjectDisc(string title)
        {
            Console.WriteLine($"Ejecting disc {title}");
        }
        // having two methods with the same name but different arguments
        // is allowed, this is called method overloading. it's not a problem
        // because c# always tell which one you  mean by what arguments
        // you give it wehn you try to call it.

        // dont confuse this with method overriding  (inheritance)

        static void  Linq()
        {
            var x = new List<string>();
            int lonestLength = x.Max(s => s.Length);

            // LINQ method swe should know:
            // - select (a mapping operation, will take each element and change it into something else)

            var listOfFirstCharacters = x.Select(s => s[0]);

            // average, Min, Max
            // all (except a bool-returning lambda - checks that all elemetns meet some condition)
            bool allShorterThan5Characters = x.All(s => s.Length < 5);

            //  - any (working  like All, but returns true if there's Any match, not just ALL matches)
            //  - where (filters the sequence for only the elements that return true)

            var onlyTheLongestElements = x.Where(s => s.Length > 20);

            // shold also know that you can chain these together

            bool b = x.Where(s => s.Length > 20)
                .Select(s => s[0])
                .All(c => c == 'a' || c == 'b');

            // b will be true if every long element starts with a or b

            // remember, LINQ uses "deferred excution" meaning it doesn't actually
            // "run the loop" until youneed the result

            List<char> listOfChars = listOfFirstCharacters.ToList();
            // -

        }
        static void Finally()
        {
            try
            {
                // this runs always
                Console.WriteLine("try");
                // until an exception in here

                // if i'm opering resources that need to be cleanup
                
                // don't put cleanup code here beause an exception beforehand might skip it
            }
            catch(ArgumentException e)
            {
                // this code runs when there is a matchign exception
                // from inside the try block.

                // only put ArgumentException-specific cleaup here

            }
            finally
            {
                // meant to CLEAUP RESOURCES
                // this code runs always, period
                // even if there was a n uncaught exception in the try block.

                // put general cleaup of "try" resources here
            }
            //DON'T PUT CLEAUP CODE HERE EITHER BECAUSE IT WILL BE SKIPPED

            // we can even have try and finally without any catch.
            // if you are using resources that you must cleaup but any error really
            // still needs to propogate up because you can't actually handle it. 

            // there is a "using statent" syntax that can replace try-finally sometimes. 
        }
    }
}
