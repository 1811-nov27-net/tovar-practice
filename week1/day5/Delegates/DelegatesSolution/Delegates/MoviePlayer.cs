using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegates
{
    class MoviePlayer
    {

        //c# supports some tings called delegates and evetns.
        // the idea here is, i can write a class that expects it's consumer
        // to actuallly "inject" behavior into ti for it to use.

        // this enables some plymorphysm you can write classes that support
        // a lot of different behaviors to be decided by other code. 

        public string CurrentMovie { get; set; }

        // this delegate type can hold any function with 0 parameters and void return
        //public delegate void MovieFinishedHandler();
        //  return type /^                        ^\ zero arguments

        // now, any variable of type "MovieFinishedHandler" can hold
        // zero-arg functions with void return

        // an event is somethig you can subscribed to with any number of functions.
        // when the event is "called" as if it itself were a function
        // all subscribing function are called.

        public delegate void MovieFinishedHandler(string title);
        // you need a delegate 
        // event delegates should always be a void returning type
        public event MovieFinishedHandler MovieFinished;

        //public event Action<string>

 
        public void PlayMovie()
        {
            Thread.Sleep(3000); // wait for 3 seconds

            Console.WriteLine($"Finished Movie {CurrentMovie}");

            // will fire an event when the movie is finished
            // and any code using this movie player can 
            // subscribe to that evetn with whatever function/code they want

            // have to check that events are not null before firing them.
            // (events without any subscribers are == null)

            if(MovieFinished != null )
            {
            // when you call and event that needs arguments, the arguments
            // will go the subsribing functions
            MovieFinished(CurrentMovie);
            }
            // or, use null conditions operator
            // "?" doe a nyull check on the left hand side first,
            // and if the left hand side is null, it'll do nothing. 
            // just syntax sugar


            //MovieFinished?.Invoke();
        }

   
    }

}
