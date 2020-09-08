using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lecture03
{
    public static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> stuff)
        {
            foreach (var item in stuff)
            {
                Console.WriteLine(item);
            }
        }
    }
}
