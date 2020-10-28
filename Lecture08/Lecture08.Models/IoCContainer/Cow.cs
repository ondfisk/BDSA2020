using System;

namespace Lecture08.Models.IoCContainer
{
    public class Cow : IAnimal
    {
        public void Hello()
        {
            Console.WriteLine("Mooh");
        }
    }
}
