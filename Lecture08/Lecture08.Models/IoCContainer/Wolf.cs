using System;

namespace Lecture08.Models.IoCContainer
{
    public class Wolf : IAnimal
    {
        public void Hello()
        {
            Console.WriteLine("Woof");
        }
    }
}
