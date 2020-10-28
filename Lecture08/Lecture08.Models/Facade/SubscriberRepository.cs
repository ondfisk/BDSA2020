using System.Collections.Generic;
using System.Linq;

namespace Lecture08.Models.Facade
{
    public interface ISubscriberRepository
    {
        IEnumerable<Subscriber> All();
    }

    public class SubscriberRepository : ISubscriberRepository
    {
        static readonly ICollection<Subscriber> _subscribers;

        static SubscriberRepository()
        {
            _subscribers = new[]
            {
                new Subscriber { Name = "Hunter S. Thompson", Email = "hunter@thompson.com" },
                new Subscriber { Name = "Carl Bernstein", Email = "carl@bernstein.com" },
                new Subscriber { Name = "Bob Woodward", Email = "bob@woodward.com" },
            };
        }

        public IEnumerable<Subscriber> All()
        {
            return _subscribers.AsEnumerable();
        }
    }
}
