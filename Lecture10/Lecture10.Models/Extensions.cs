using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lecture10.Models
{
    public static class Extensions
    {
        public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> items)
        {
            var results = new List<T>();
            await foreach (var item in items)
            {
                results.Add(item);
            }
            return results;
        }

        public static Shared.Gender ToGender(this Entities.Gender gender) => Enum.Parse<Shared.Gender>(gender.ToString());

        public static Entities.Gender ToGender(this Shared.Gender gender) => Enum.Parse<Entities.Gender>(gender.ToString());
    }
}
