using System;
using System.Collections.Generic;

namespace Lecture08.Models.Facade
{
    public interface INotifier
    {
        void Notify(Article article);
    }

    public class Notifier : INotifier
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public Notifier(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public void Notify(Article article)
        {
            Console.WriteLine("Notifying:");
            foreach (var subscriber in _subscriberRepository.All())
            {
                Console.WriteLine($"- {subscriber.Name}");
            }
        }
    }
}
