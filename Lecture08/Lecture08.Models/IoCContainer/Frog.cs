using System;

namespace Lecture08.Models.IoCContainer
{
    public class Frog : IAnimal
    {
        public void Hello()
        {
            Console.WriteLine("Ribbit");
        }
    }
}
