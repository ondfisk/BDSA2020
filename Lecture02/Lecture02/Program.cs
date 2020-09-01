using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Lecture02
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var number in StreamNumbers())
            {
                Console.WriteLine(number);
            }
        }

        static IEnumerable<int> StreamNumbers()
        {
            var i = 0;

            while (true)
            {
                yield return i++;
            }
        }
    }
}
