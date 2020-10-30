using Lecture09.App.Models;
using Lecture09.App.Services;
using Lecture09.App.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Lecture09.App.Tests.ViewModels
{
    public class SuperheroCreateViewModelTests
    {
        [Fact]
        public void Ctor_sets_Title_to_New_Superhero()
        {
            var client = new Mock<IRestClient>();

            var vm = new SuperheroCreateViewModel(client.Object);

            Assert.Equal("New Superhero", vm.Title);
        }

        [Fact]
        public void SaveCommand_saves_to_api()
        {
            var client = new Mock<IRestClient>();

            var location = new Uri("https://api.com/superheroes/42");
            client.Setup(s => s.PostAsync("superheroes", It.IsAny<SuperheroCreateDTO>())).ReturnsAsync(location);

            var vm = new SuperheroCreateViewModel(client.Object)
            {
                Name = "name",
                AlterEgo = "alterEgo",
                Occupation = "occupation",
                CityName = "cityName",
                PortraitUrl = "https://image.com/portrait.jpg",
                BackgroundUrl = "https://image.com/background.jpg",
                FirstAppearance = 2000,
                Gender = Gender.Male,
                Powers = $"power1{Environment.NewLine}power2"
            };

            vm.SaveCommand.Execute(null);

            client.Verify(s => s.PostAsync("superheroes", It.Is<SuperheroCreateDTO>(h =>
                h.Name == "name" &&
                h.AlterEgo == "alterEgo" &&
                h.Occupation == "occupation" &&
                h.CityName == "cityName" &&
                h.PortraitUrl == "https://image.com/portrait.jpg" &&
                h.BackgroundUrl == "https://image.com/background.jpg" &&
                h.FirstAppearance == 2000 &&
                h.Gender == Gender.Male &&
                new HashSet<string> { "power1", "power2" }.SetEquals(h.Powers)
            )));

            // Ensure not busy when command finished
            Assert.False(vm.IsBusy);
        }
    }
}
