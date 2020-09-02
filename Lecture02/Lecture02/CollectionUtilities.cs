using System;
using System.Collections.Generic;

namespace Lecture02
{
    public static class CollectionUtilities
    {
        public static IEnumerable<int> GetEven(IEnumerable<int> list)
        {
            foreach (var number in list)
            {
                if (number % 2 == 0)
                {
                    if (number == 42)
                    {
                        yield return number;
                        yield break;
                    }
                    yield return number;
                }
            }
        }

        public static bool Find(int[] list, int number)
        {
            throw new NotImplementedException();
        }

        public static ISet<int> Unique(IEnumerable<int> numbers)
        {
            // var set = new HashSet<int>();

            // foreach (var number in numbers)
            // {
            //     set.Add(number);
            // }

            // return set;

            return new HashSet<int>(numbers);
        }

        public static IList<int> Reverse(IList<int> numbers)
        {
            throw new NotImplementedException();
        }

        public static void Sort(List<Duck> ducks, IComparer<Duck> comparer = null)
        {
            ducks.Sort(comparer);
        }

        public static IDictionary<int, Duck> ToDictionary(IEnumerable<Duck> ducks)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Duck> GetOlderThan(IEnumerable<Duck> ducks, int age)
        {
            throw new NotImplementedException();
        }
    }
}
