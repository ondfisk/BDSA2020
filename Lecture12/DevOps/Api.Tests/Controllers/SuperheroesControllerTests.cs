using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Lecture12.Models;
using Lecture12.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Lecture12.Api.Tests.Controllers
{
    public class SuperheroesControllerTests
    {
        [Fact]
        public async Task Get_given_existing_returns_superhero()
        {
            var superhero = new SuperheroDetailsDTO();

            var repository = new Mock<ISuperheroRepository>();
            repository.Setup(s => s.Read(42)).ReturnsAsync(superhero);

            var controller = new SuperheroesController(repository.Object);

            var actual = await controller.Get(42);

            Assert.Equal(superhero, actual.Value);
        }

        [Fact]
        public async Task Get_given_non_existing_returns_404()
        {
            var repository = new Mock<ISuperheroRepository>();

            var controller = new SuperheroesController(repository.Object);

            var actual = await controller.Get(42);

            Assert.IsType<NotFoundResult>(actual.Result);
        }
    }
}
