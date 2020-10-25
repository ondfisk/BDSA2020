using System;

namespace Lecture08.Models.Facade
{
    public class Facade
    {
        private readonly INotifier _notifier;
        private readonly IPublisher _publisher;
        private readonly IArchiver _archiver;
        private readonly IPeopleRepository _peopleRepository;

        public Facade(INotifier notifier, IPublisher publisher, IArchiver archiver, IPeopleRepository peopleRepository)
        {
            _notifier = notifier;
            _publisher = publisher;
            _archiver = archiver;
            _peopleRepository = peopleRepository;
        }

        public void Publish(Article article)
        {
            Console.WriteLine("Publishing");
            _publisher.PublishOnline(article);

            Console.WriteLine("Archiving");
            _archiver.Archive(article);

            var people = _peopleRepository.All();

            Console.WriteLine("Notifying");
            _notifier.Notify(article, people);
        }
    }
}
