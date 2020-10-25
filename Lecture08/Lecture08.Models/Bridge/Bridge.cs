using System;
using System.Threading.Tasks;

namespace Lecture08.Models.Bridge
{
    public class Bridge
    {
        private readonly ICharacterRepository _repository;

        public Bridge(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task PrintAll()
        {
            foreach (var character in await _repository.ReadAsync())
            {
                Console.WriteLine(character);
            }
        }
    }
}
