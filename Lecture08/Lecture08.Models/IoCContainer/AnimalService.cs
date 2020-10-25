namespace Lecture08.Models.IoCContainer
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimal _animal;

        public AnimalService(IAnimal animal)
        {
            _animal = animal;
        }

        public void Speak()
        {
            _animal.Hello();
        }
    }
}
