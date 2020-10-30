using Lecture09.App.Models;
using Lecture09.App.Services;
using Lecture09.App.ViewModels;
using Moq;
using Xunit;

namespace Lecture09.App.Tests.ViewModels
{
    public class SuperheroDetailsViewModelTests
    {
        [Fact]
        public void LoadCommand_populates_Superhero()
        {
            var detailsDTO = new SuperheroDetailsDTO
            {
                Id = 42,
                Name = "name",
                AlterEgo = "alterEgo",
                Occupation = "occupation",
                CityName = "cityName",
                PortraitUrl = "https://image.com/portrait.jpg",
                BackgroundUrl = "https://image.com/background.jpg",
                FirstAppearance = 2000,
                Gender = Gender.Male,
                Powers = new[] { "power1", "power2" }
            };

            var client = new Mock<IRestClient>();
            client.Setup(s => s.GetAsync<SuperheroDetailsDTO>("superheroes/42")).ReturnsAsync(detailsDTO);

            var vm = new SuperheroDetailsViewModel(client.Object);

            var listDTO = new SuperheroListDTO
            {
                Id = 42,
                AlterEgo = "alterEgo",
                Name = "name",
                PortraitUrl = "https://image.com/image.jpg"
            };

            vm.LoadCommand.Execute(listDTO);

            Assert.Equal(42, vm.Id);
            Assert.Equal("alterEgo", vm.AlterEgo);
            Assert.Equal("name", vm.Name);
            Assert.Equal("occupation", vm.Occupation);
            Assert.Equal("cityName", vm.CityName);
            Assert.Equal("https://image.com/portrait.jpg", vm.PortraitUrl);
            Assert.Equal("https://image.com/background.jpg", vm.BackgroundUrl);
            Assert.Equal(2000, vm.FirstAppearance);
            Assert.Equal(Gender.Male, vm.Gender);
            Assert.Collection(vm.Powers, 
                s => Assert.Equal("power1", s),
                s => Assert.Equal("power2", s)
            );

            // Ensure not busy when command finished
            Assert.False(vm.IsBusy);
        }
    }
}
