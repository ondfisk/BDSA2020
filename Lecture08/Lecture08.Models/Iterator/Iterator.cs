using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Lecture08.Models.Iterator
{
    public class Iterator
    {
        public static void Run()
        {
            IEnumerable<string> collection = new[] { "foo", "bar", "baz", "qux" };

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }

        public static void BigIntegerDemo()
        {
            foreach (var number in new CountToInfinity().Skip(BigInteger.Parse("97125892089573210894324210498321094701293487092183740921387312049873242314124214312098473120")))
            {
                Console.WriteLine(number);
            }
        }

        public static void ChuckNorris()
        {
            foreach (var number in new CountToInfinity())
            {
                Console.Write($"{number} ");
            }
            foreach (var number in new CountToInfinity())
            {
                Console.Write($"{number} ");
            }
        } // Chuck Norris has counted to infinity. Twice.
    }
}