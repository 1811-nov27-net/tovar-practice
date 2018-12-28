using System;
using System.Collections.Generic;

namespace Collections
{
    class Program // this is internal by defailt
    {
        static void Main(string[] args) // this is private by default
        {
            Arrays();
            Lists();
            Sets();
        }
        static void Arrays()
        {
            int[] intArray = new int[10];// lendth 10 array (brackets not parens)
            //
            Console.WriteLine(intArray[5]);

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i]);

            }
            Console.WriteLine();

            foreach (var item in intArray)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            // you can use a foreach loop with anything implenting the 
            //IEnumerable interface, which is one of the most important interfaces in C#. (also used with LINKQ!)

            // jagged/ nested arrays

            int[][] arraysOfFourArrays = new int[4][];
            // this is now an array of four nulls
            Console.WriteLine(arraysOfFourArrays[0][0]);

            arraysOfFourArrays[0] = new int[3];


            // multi-dimentioanl arrays

            int[,] trueMultiDArray = new int[5, 5];

            trueMultiDArray[3, 4] = 5;
            // use this instead of jagged array generally

            // actually don't use arrays hardly ever
            // instead use generic collection classes for everything
            // that's not some performance-critical loop

            // (nver pre-optimize your code, write it the simple/understandable way frist,
            // and in necessary, later, profile, and optimize where actually useful.)




        }
        static void Lists()
        {
            var list = new List<bool>();

            list.Add(true);
            list.Add(true);
            list.Add(false);

            // list have dynamic length, grow and shrink as you add and remove values.

            var list2 = new List<bool>() { false, false, false};
            list2.AddRange(list);

            var x = list2[2];

            list[1] = true;


        }
        static void Sets()
        {
            var set = new HashSet<string>();

            // sets have no particular order to them and do not allow duplicates

            // adding an element that's already in there has zero effect.

            set.Add("abc");
            set.Add("abc"); // does nothing
            set.Add("fdc");

            Console.WriteLine(set.Count);// prints 2

            // this is abased on the mathematical concept of "set"
            // so we have standar "set operations"
            // comparisons like subset


            // sets are very fast to search for a specific value even if there's millions of things in the set
            // becasue it's implemented with a "hashtable"

            // slower to iterate over than list but faster to look up

        }

        static void StringEquality()
        {
            // in some languages, == always means  "references the same object in memory"
            // whiel, Equals is for "references an EQIVALENT object"


            bool stringEqual = "abc" == "abc";
            Console.WriteLine(stringEqual);

            // in C#, string with == compare value, not reference.
            // we have operator overloading in C# (though we don't use it much)
            // and you can override == to  do value comparison too on your classes.

            // for basically all refence types except string, == compares "exact same obejct yes or no"

        }
        static void Dictinaries ()
        {
            var dict = new Dictionary<string, string>();

            // depending on abstractions not concretions. i.e., on interfaces, not concrete
            // implementations/classes so the actual class should be swapped out later easily. 
            IDictionary<string, string> dict3 = new Dictionary<string, string>();

            dict.Add("Germany", "Berlin");
            dict.Add("USA", "Washington, DC");

            dict["Mexico"] = "Mexico City"; // inserts/overrides

            var dict2 = new Dictionary<string, string>()
            {
                {"Germany", "Berlin" },
                {"Mexico", "Mexico City" }
            };

            // you can use foreach with dictironaries in a few ways

            foreach(string key in dict.Keys) { }
            foreach(string key in dict.Values) { }
            foreach(KeyValuePair<string, string> pair in dict) {
                // pair.Key
                //pair.Value
            }


        }
    }
}
