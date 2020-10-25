using System;
using System.Collections.Generic;

namespace Lecture08.Models.Facade
{
    public interface INotifier
    {
        void Notify(Article article, IEnumerable<Person> people);
    }

    public class Notifier : INotifier
    {
        public void Notify(Article article, IEnumerable<Person> people)
        {
            Console.WriteLine("Notifying:");
            foreach (var person in people)
            {
                Console.WriteLine($"- {person.Name}");
            }
        }
    }
}
