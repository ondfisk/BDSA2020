using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static Lecture02.CollectionUtilities;

namespace Lecture02
{
    class Program
    {
        static void Main(string[] args)
        {
            // foreach (var number in StreamNumbers())
            // {
            //     Console.WriteLine(number);
            // }

            // foreach (var number in GetEven(StreamNumbers()))
            // {
            //     Console.WriteLine(number);
            // }

            // var ducks = Duck.Ducks.ToList();

            // Sort(ducks, new DuckAgeComparer());

            // foreach (var duck in ducks)
            // {
            //     Console.WriteLine(duck);
            // }

            // Sort(ducks);

            // foreach (var duck in ducks)
            // {
            //     Console.WriteLine(duck);
            // }

            var var = new Variance();
            // var.ArrayTypeCovariance();
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
