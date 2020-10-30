using Lecture09.App.Models;
using Lecture09.App.Services;
using Lecture09.App.ViewModels;
using Moq;
using Xunit;

namespace Lecture09.App.Tests.ViewModels
{
    public class SuperheroesViewModelTests
    {
        [Fact]
        public void Ctor_sets_Title_to_Browse()
        {
            var client = new Mock<IRestClient>();

            var vm = new SuperheroesViewModel(client.Object);

            Assert.Equal("Browse", vm.Title);
        }

        [Fact]
        public void LoadCommand_populates_Items_from_api()
        {
            var batman = new SuperheroListDTO();
            var superman = new SuperheroListDTO();
            var heroes = new[] { batman, superman };

            var client = new Mock<IRestClient>();
            client.Setup(s => s.GetAllAsync<SuperheroListDTO>("superheroes")).ReturnsAsync(heroes);

            var vm = new SuperheroesViewModel(client.Object);

            vm.LoadCommand.Execute(null);

            Assert.Collection(vm.Items,
                a => Assert.Equal(a, batman),
                a => Assert.Equal(a, superman)
            );

            // Ensure not busy when command finished
            Assert.False(vm.IsBusy);
        }
    }
}
