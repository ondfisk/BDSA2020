using System;

namespace Lecture08.Models.Facade
{
    public class Facade
    {
        private readonly INotifier _notifier;
        private readonly IPublisher _publisher;
        private readonly IArchiver _archiver;

        public Facade(IArchiver archiver, IPublisher publisher, INotifier notifier)
        {
            _archiver = archiver;
            _publisher = publisher;
            _notifier = notifier;
        }

        public void Publish(Article article)
        {
            Console.WriteLine("Publishing");
            _publisher.PublishOnline(article);

            Console.WriteLine("Archiving");
            _archiver.Archive(article);

            Console.WriteLine("Notifying");
            _notifier.Notify(article);
        }
    }
}
