using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lecture08.Models.Bridge
{
    public interface ICharacterRepository : IDisposable
    {
        Task<int> CreateAsync(Character character);

        Task<Character> FindAsync(int id);

        Task<IEnumerable<Character>> ReadAsync();

        Task<bool> UpdateAsync(Character character);

        Task<bool> DeleteAsync(int id);
    }
}
