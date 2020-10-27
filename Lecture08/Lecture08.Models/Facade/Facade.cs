using System;

namespace Lecture08.Models.Facade
{
    public class Facade
    {
        private readonly Notifier _notifier = new Notifier();
        private readonly Publisher _publisher = new Publisher();
        private readonly Archiver _archiver = new Archiver();

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
