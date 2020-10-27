using System;
using System.Collections.Generic;

namespace Lecture08.Models.Facade
{
    public class Notifier
    {
        private readonly SubscriberRepository _peopleRepository = new SubscriberRepository();

        public void Notify(Article article)
        {
            Console.WriteLine("Notifying:");
            foreach (var person in _peopleRepository.All())
            {
                Console.WriteLine($"- {person.Name}");
            }
        }
    }
}
