using System;
using System.Collections.Generic;
using System.Text;

namespace LINQAndTestingLibrary
{
   public static class StaticStuff
    {
        public static bool Compare<T1, T2>(T1 first, T2 second)
        {
            return first.Equals(second);
        }
        public static void Example()
        {
            // type parameters in generic methods are usually inferred
            //  Compare<int, string>(1, "5");
            Compare<int, string>(1, "5");
        }
    }
}
