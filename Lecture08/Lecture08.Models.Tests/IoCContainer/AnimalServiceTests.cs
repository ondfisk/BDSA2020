using Lecture08.Models.IoCContainer;
using Moq;
using Xunit;

namespace Lecture08.Models.Tests.IoCContainer
{
    public class AnimalServiceTests
    {
        [Fact]
        public void Speak_calls_animal_Hello()
        {
            var mock = new Mock<IAnimal>();

            var service = new AnimalService(mock.Object);

            service.Speak();

            mock.Verify(a => a.Hello(), Times.Once);
        }
    }
}
