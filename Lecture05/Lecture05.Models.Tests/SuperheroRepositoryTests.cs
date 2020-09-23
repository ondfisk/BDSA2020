using System;
using Lecture05.Entities;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using static Lecture05.Models.Tests.TestDataGenerator;
using static Lecture05.Models.Response;

namespace Lecture05.Models.Tests
{
    public class SuperheroRepositoryTests
    {
        [Fact]
        public void Given_existing_id_when_Delete_it_removes_entity()
        {
            var entity = new Superhero();

            var context = new Mock<ISuperheroContext>();
            context.Setup(s => s.Superheroes.Find(42)).Returns(entity);

            var repository = new SuperheroRepository(context.Object);

            repository.Delete(42);

            context.Verify(s => s.Superheroes.Remove(entity));
        }

        [Fact]
        public void Given_existing_id_when_Delete_it_saves_changes()
        {
            var entity = new Superhero();

            var context = new Mock<ISuperheroContext>();
            context.Setup(s => s.Superheroes.Find(42)).Returns(entity);

            var repository = new SuperheroRepository(context.Object);

            repository.Delete(42);

            context.Verify(s => s.SaveChanges());
        }

        [Fact]
        public void Given_existing_id_when_Delete_it_returns_Deleted()
        {
            var entity = new Superhero();

            var context = new Mock<ISuperheroContext>();
            context.Setup(s => s.Superheroes.Find(42)).Returns(entity);

            var repository = new SuperheroRepository(context.Object);

            var result = repository.Delete(42);

            Assert.Equal(Deleted, result);
        }

        [Fact]
        public void Test()
        {
            using var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var builder = new DbContextOptionsBuilder<SuperheroContext>().UseSqlite(connection);
            using var context = SuperheroContext(builder.Options);
            context.Database.EnsureCreated();

            Assert.Equal(2, context.Superheroes.Count());
        }
    }
}
