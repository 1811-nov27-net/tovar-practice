using System;
using System.Collections.Generic;

namespace CSharpBasicsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ocal variables and types

            int x = 0;
            double y = 4.58; // allows decimal - 64 bit float
            decimal z = 5.001m; //even more preciision - for financial etc

            string s = "string";
            bool b = true;

            b = false;

            // base calss of "everything" --> object

            object o = true;

           // var (compiler type inference) just a way to declare variables that will save you a bit of time

            var xyz = "hello";
            var b1 = true;

            // user var when the type is clear to the person reading the code       
            // don't use it when it obscures usefull context.


            //control sturctures
            //loops

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            while (false)
            {
                //  while loop
            }

            do
            {

            } while (false);

            if (true)
            {

            }
            else
            {

            }

            if (true)
            {

            }
            else if(false)
            {

            }
            else
            {

            }

            //list is a class define in another namaspace
            //therefore it needs a "using statment" at the top of the file
            // like an import in other languages

            List<string> list = new List<string>();

            list.Add("axel");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            //object oriented
            //  have objects which associate data and related behavior to represent "entities"/nouns
            //  we create those objects from templates called classes, which define a contract with those
            //  objects at run time.

            // part of the .NET ecosystem/platform

            // strongly typed (more presicely, statically typed)
            // statically types means, variables are locked to a certain type at compile time and cannot change.

            // unified type system
            // "primitive" (types with value semantics instead of reference semantics)
            // "also" inherit from object. 

            // garbage collection --> managed language
            // "managed" language (memory is managed for you)
            // the runtime is responsible for freeing unused objects from memory. saves developer time, fewer bugs,
            // some performanace penalty

            // functions are not quite first-class but in practice more or less
            // c sharp is somewhat functional, especially in practice with LINQ
            // LINQ (one of the best aprts C#)
            // (Language-Integrated Query Language)

            // asynchronous programming support with TPL (Task processing library)
            
            //how to 
            //what are some of the methods in the .list class that we used?
        

        
        }
    }
}
