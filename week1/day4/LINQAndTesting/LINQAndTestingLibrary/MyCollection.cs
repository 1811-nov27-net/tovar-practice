using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQAndTestingLibrary
{
    /// <summary>
    /// a list with some extra helper methods
    /// </summary>
    /// <remarks>
    /// two stragegies we could use to leverage the builtin collection classes:
    /// -- inheritance (MyCollection IS A List)
    /// -- composition (MyCollection HAS A List)
    /// 
  
    /// </remarks>
    public class MyCollection : MyGenericCollection<string>
    {
        // in c#, there's regualr parameters - maybe a method Add can accept 2 and 2, 5 and 3,
        // 1 and 0, it can accept many values.
        // there's also "type parameters" which means, a class or a method
        // can work with different types without being a whole new class/method
        // the way we do type parameters is with angle brackets <type> 
        //some, like Dictionary, take more than one e.g. Dictionary<string, int>
        // "type parameters" aka generics


        // "readonly" just means i can't reassign "_list" to a different object
        // later.
        private readonly List<string> _list = new List<string>();

        // every class has at least one constructor. 
        // if you don't define one, it has a default constructor without any parameters - 
        //  "public MyCollection() {}"
        // but, as soon as you define any constructor, that default one will not be added.

        public void Sort()
        {
            _list.Sort();
        }
        public void Add(string item)
        {
            _list.Add(item);
        }

        // property without a "set"
        // calling code can say "coll.length" instead of coll.GetLength
        public int Length => _list.Count;

        public string Get(int index)
        {
            return _list[index];
        }

        public string longest()
        {
            int longestlength = -1;
            string longest = "";

            foreach (var item in _list)
            {
                if (item != null && item.Length > longestlength)
                {
                    longestlength = item.Length;
                    longest = item;
                }
            }
            return longest;
        }

        public double AverageLength()
        {
            return _list.Average(x => x.Length);

            // much nicer than manual loop and less error-prone
        }

        public IEnumerable<int> Lengths()
        {
            return _list.Select(x => x.Length);
        }
        public int NumberofAs()
        {
            return _list.Count(x => (x != null && x.Length > 0 && x[0] == 'a'));
            // we are using "lambda expressions"
            // which are linke metohds but you can pass them as parameters
            // and assign them to variables.
        }

        private static bool ContainsVowel(string s)
        {

            // Func<char, bool> isVowel = (c => "AEIOUaeiou".Contains(c));
            // true if, for ANY element, it is true that...
            return s.Any(
                x => "AEIOUaeiou".Contains(x)
            );
        }
        public int NumberWithVowels()
        {
            return _list.Count(ContainsVowel);
        }

        // LINQ (and IEnumerable itself) uses "deferred execution"

        public string FirstAlphabetical()
        {
            // orderby will sort the sequence by some "key"
            // "x => x" means, sort the strings using regular string sort
            IEnumerable<string> sorted = _list.OrderBy(x => x);

            // we haven't actually sorted the list in any way
            // or iterated over it self
            //  only set up how we WILL iterate, when we need the values.

            var first = sorted.First();
            // that method call actually ran the sort, and then discarded everything
            // but the first entry.
            return first;
        }
    }
}
