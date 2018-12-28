using System;
using System.Collections.Generic;
using System.Text;

namespace LINQAndTestingLibrary
{
    /// <summary>
    /// make class generic with angle brackets in its definition
    ///  - this defines a type parameter in that class, by convention,
    ///  - call it "T" if there's only one.
    ///  
    /// generic / type parameter constraints: 
    ///     you can require that it is derived form some type
    ///         MyGenericCollectio<T> where T : some type
    ///       
    /// </summary>
   public  class MyGenericCollection<T> where T : new()
    {
        protected List<T> _list = new List<T>();
        // we don't know what T is, it could be anything
        // so this member will have a different type for every instance of 
        // MyGenericCollection

        public void AddDefaultValue()
        {
            _list.Add(new T());
            // not allowed unless we have "new()" constraint where T is declared
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

    }
}
