using System;
using Lecture05.Entities;
using Moq;
using Xunit;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using static Lecture05.Models.Response;

namespace Lecture05.Models.Tests
{
    public class SuperheroRepositoryTests : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly SuperheroContext _context;
        private readonly SuperheroRepository _repository;

        public SuperheroRepositoryTests()
        {
            // Arrange
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            var builder = new DbContextOptionsBuilder<SuperheroContext>().UseSqlite(_connection);
            _context = new SuperheroContext(builder.Options);
            _context.Database.EnsureCreated();
            _context.GenerateTestData();

            _repository = new SuperheroRepository(_context);
        }

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
            using var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var builder = new DbContextOptionsBuilder<SuperheroContext>().UseSqlite(connection);
            using var context = new SuperheroContext(builder.Options);
            context.Database.EnsureCreated();
            context.GenerateTestData();

            Assert.Equal(2, context.Superheroes.Count());
        }

        [Fact]
        public void Given_existing_id_When_Delete_it_removes_hero_and_returns_Deleted()
        {
            // Act
            var result = _repository.Delete(1);

            // Assert
            Assert.Null(_context.Superheroes.Find(1));
            Assert.Equal(Deleted, result);
        }

        [Fact]
        public void Given_existing_id_When_Delete_it_removes_hero_and_returns_Deleted_2()
        {
            // Act
            var result = _repository.Delete(1);

            // Assert
            Assert.Null(_context.Superheroes.Find(1));
            Assert.Equal(Deleted, result);
        }

        [Fact]
        public void Given_non_existing_id_When_Delete_it_returns_not_found()
        {
            // Act
            var result = _repository.Delete(42);

            // Assert
            Assert.Equal(NotFound, result);
        }

        [Fact]
        public void Given_hero_create_creates()
        {
            var hero = new SuperheroCreateDTO
            {
                Name = "Selina Kyle",
                AlterEgo = "Catwoman",
                CityName = "Gotham City",
                Gender = Gender.Female
            };

            var id =  _repository.Create(hero);

            Assert.Equal(3, id);

            var entity = _context.Superheroes.Include(c => c.City).FirstOrDefault(c => c.Id == id);

            Assert.Equal("Selina Kyle", entity.Name);
            Assert.Equal("Gotham City", entity.City.Name);
        }

        public void Dispose()
        {
            _connection.Dispose();
            _context.Dispose();
        }
    }
}
