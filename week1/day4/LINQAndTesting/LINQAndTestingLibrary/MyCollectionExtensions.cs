using System;
using System.Collections.Generic;
using System.Text;

namespace LINQAndTestingLibrary
{
   public static class MyCollectionExtensions
    {
        public static bool Empty(this MyCollection col)
        {
            return col.Length == 0;
            // (equiv to "if length 0, return true, else return false")
            // better to to just return the comparison itself since it's already true or false.
        }

        // as long as someone has a "using" statement to this namespae, every
        // MyCollection they see will have this ectra method on it.
    }
}
