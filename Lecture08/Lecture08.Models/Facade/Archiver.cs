using System;

namespace Lecture08.Models.Facade
{
    public interface IArchiver
    {
        void Archive(Article article);
    }

    public class Archiver : IArchiver
    {
        public void Archive(Article article)
        {
            Console.WriteLine($"Archived {article.Title} by {article.Author}");
        }
    }
}
