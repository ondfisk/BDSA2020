using System.Collections.Generic;
using System.Linq;

namespace Lecture08.Models.Facade
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> All();
    }

    public class PeopleRepository : IPeopleRepository
    {
        static readonly ICollection<Person> _people;

        static PeopleRepository()
        {
            _people = new[]
            {
                new Person { Name = "Hunter S. Thompson", Email = "hunter@thompson.com" },
                new Person { Name = "Carl Bernstein", Email = "carl@bernstein.com" },
                new Person { Name = "Bob Woodward", Email = "bob@woodward.com" },
            };
        }

        public IEnumerable<Person> All()
        {
            return _people.AsEnumerable();
        }
    }
}
