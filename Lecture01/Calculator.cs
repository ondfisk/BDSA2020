using System;

namespace Lecture01
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            // if (numbers == string.Empty)
            // {
            //     return 0;
            // }

            var items = numbers.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var result = 0;

            foreach(var item in items)
            {
                if (int.TryParse(item, out var number))
                {
                    result += number;
                }
                else
                {
                    return -1;
                }
            }

            return result;
        }
    }
}
