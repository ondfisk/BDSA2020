using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Lecture06.Entities;
using static Lecture06.Entities.Gender;
using static Lecture06.Models.Response;
using System.Threading.Tasks;

namespace Lecture06.Models.Tests
{
    public class SuperheroRepositoryTests : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly SuperheroContext _context;
        private readonly SuperheroRepository _repository;

        public SuperheroRepositoryTests()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            var builder = new DbContextOptionsBuilder<SuperheroContext>().UseSqlite(_connection);

            _context = new SuperheroContext(builder.Options);
            _context.Database.EnsureCreated();
            _context.GenerateTestData();

            _repository = new SuperheroRepository(_context);
        }

        [Fact]
        public async Task Given_superhero_with_existing_city_When_Create_it_Creates_superhero_and_returns_id()
        {
            var superhero = new SuperheroCreateDTO
            {
                Name = "Selina Kyle",
                AlterEgo = "Catwoman",
                CityName = "Gotham City",
                Occupation = "Thief",
                Gender = Gender.Female,
                FirstAppearance = 1940,
                Powers = new HashSet<string>
                {
                    "exceptional martial artist",
                    "gymnastic ability",
                    "combat skill"
                }
            };

            var id = await _repository.Create(superhero);

            Assert.Equal(3, id);

            var entity = _context.Superheroes
                .Include(h => h.City)
                .Include(h => h.Powers)
                .ThenInclude(h => h.Power)
                .FirstOrDefault(h => h.Id == id);

            Assert.Equal("Selina Kyle", entity.Name);
            Assert.Equal("Catwoman", entity.AlterEgo);
            Assert.Equal("Thief", entity.Occupation);
            Assert.Equal(Female, entity.Gender);
            Assert.Equal(1940, entity.FirstAppearance);
            Assert.Equal(2, entity.CityId);
            Assert.Equal("Gotham City", entity.City.Name);
            Assert.Equal(new[]
                {
                    "exceptional martial artist",
                    "gymnastic ability",
                    "combat skill"
                },
                entity.Powers.Select(p => p.Power.Name).ToHashSet()
            );
        }

        [Fact]
        public async Task Given_superhero_with_new_city_When_Create_it_Creates_superhero_and_returns_id()
        {
            var superhero = new SuperheroCreateDTO
            {
                Name = "Diana",
                AlterEgo = "Wonder Woman",
                CityName = "Themyscira",
                Occupation = "Amazon Princess",
                Gender = Gender.Female,
                FirstAppearance = 1941,
                Powers = new HashSet<string>
                {
                    "super strength",
                    "invulnerability",
                    "flight",
                    "combat skill",
                    "superhuman agility",
                    "healing factor",
                    "magic weaponry"
                }
            };

            var id = await _repository.Create(superhero);

            var entity = await _context.Superheroes
                .Include(h => h.City)
                .Include(h => h.Powers)
                .ThenInclude(h => h.Power)
                .FirstOrDefaultAsync(h => h.Id == id);

            Assert.Equal("Diana", entity.Name);
            Assert.Equal("Wonder Woman", entity.AlterEgo);
            Assert.Equal("Amazon Princess", entity.Occupation);
            Assert.Equal(Female, entity.Gender);
            Assert.Equal(1941, entity.FirstAppearance);
            Assert.Equal(3, entity.CityId);
            Assert.Equal("Themyscira", entity.City.Name);
            Assert.Equal(new[]
                {
                    "super strength",
                    "invulnerability",
                    "flight",
                    "combat skill",
                    "superhuman agility",
                    "healing factor",
                    "magic weaponry"
                },
                entity.Powers.Select(p => p.Power.Name).ToHashSet()
            );
        }

        [Fact]
        public async Task Given_existing_id_When_Read_it_returns_superhero()
        {
            var superhero = await _repository.Read(2);

            Assert.Equal("Bruce Wayne", superhero.Name);
            Assert.Equal("Batman", superhero.AlterEgo);
            Assert.Equal("CEO of Wayne Enterprises", superhero.Occupation);
            Assert.Equal(Male, superhero.Gender);
            Assert.Equal(1939, superhero.FirstAppearance);
            Assert.Equal(2, superhero.CityId);
            Assert.Equal("Gotham City", superhero.CityName);
            Assert.Equal(new[]
                {
                    "exceptional martial artist",
                    "combat strategy",
                    "inexhaustible wealth",
                    "brilliant deductive skills",
                    "advanced technology"
                },
                superhero.Powers
            );
        }

        [Fact]
        public async Task Given_non_existing_id_When_Read_it_returns_null()
        {
            var result = await _repository.Read(42);

            Assert.Null(result);
        }

        [Fact]
        public async Task Read_returns_superheroes()
        {
            var result = await _repository.Read();

            Assert.Equal(2, result.Count);

            var superman = result.First();
            var batman = result.Last();

            Assert.Equal(1, superman.Id);
            Assert.Equal("Clark Kent", superman.Name);
            Assert.Equal("Superman", superman.AlterEgo);

            Assert.Equal(2, batman.Id);
            Assert.Equal("Bruce Wayne", batman.Name);
            Assert.Equal("Batman", batman.AlterEgo);
        }

        [Fact]
        public async Task Update_turns_Batman_into_Catwoman()
        {
            var superhero = new SuperheroUpdateDTO
            {
                Id = 2,
                Name = "Selina Kyle",
                AlterEgo = "Catwoman",
                CityName = "Gotham City",
                Occupation = "Thief",
                Gender = Gender.Female,
                FirstAppearance = 1940,
                Powers = new HashSet<string>
                {
                    "exceptional martial artist",
                    "gymnastic ability",
                    "combat skill"
                }
            };

            var result = await _repository.Update(superhero);

            Assert.Equal(Updated, result);

            var entity = await _context.Superheroes
                .Include(h => h.City)
                .Include(h => h.Powers)
                .ThenInclude(h => h.Power)
                .FirstOrDefaultAsync(h => h.Id == 2);

            Assert.Equal("Selina Kyle", entity.Name);
            Assert.Equal("Catwoman", entity.AlterEgo);
            Assert.Equal("Thief", entity.Occupation);
            Assert.Equal(Female, entity.Gender);
            Assert.Equal(1940, entity.FirstAppearance);
            Assert.Equal(2, entity.CityId);
            Assert.Equal("Gotham City", entity.City.Name);
            Assert.Equal(new[]
                {
                    "exceptional martial artist",
                    "gymnastic ability",
                    "combat skill"
                },
                entity.Powers.Select(p => p.Power.Name).ToHashSet()
            );
        }

        [Fact]
        public async Task Update_turns_Superman_into_Wonder_Woman()
        {
            var superhero = new SuperheroUpdateDTO
            {
                Id = 1,
                Name = "Diana",
                AlterEgo = "Wonder Woman",
                CityName = "Themyscira",
                Occupation = "Amazon Princess",
                Gender = Gender.Female,
                FirstAppearance = 1941,
                Powers = new HashSet<string>
                {
                    "super strength",
                    "invulnerability",
                    "flight",
                    "combat skill",
                    "superhuman agility",
                    "healing factor",
                    "magic weaponry"
                }
            };

            var result = await _repository.Update(superhero);

            Assert.Equal(Updated, result);

            var entity = await _context.Superheroes
                .Include(h => h.City)
                .Include(h => h.Powers)
                .ThenInclude(h => h.Power)
                .FirstOrDefaultAsync(h => h.Id == 1);

            Assert.Equal("Diana", entity.Name);
            Assert.Equal("Wonder Woman", entity.AlterEgo);
            Assert.Equal("Amazon Princess", entity.Occupation);
            Assert.Equal(Female, entity.Gender);
            Assert.Equal(1941, entity.FirstAppearance);
            Assert.Equal(3, entity.CityId);
            Assert.Equal("Themyscira", entity.City.Name);
            Assert.Equal(new[]
                {
                    "super strength",
                    "invulnerability",
                    "flight",
                    "combat skill",
                    "superhuman agility",
                    "healing factor",
                    "magic weaponry"
                },
                entity.Powers.Select(p => p.Power.Name).ToHashSet()
            );
        }


        [Fact]
        public async Task Given_non_existing_id_When_Update_it_returns_not_found()
        {
            var superhero = new SuperheroUpdateDTO { Id = 42 };

            var result = await _repository.Update(superhero);

            Assert.Equal(NotFound, result);
        }

        [Fact]
        public async Task Given_existing_id_When_Delete_it_removes_superhero_and_returns_Deleted()
        {
            var result = await _repository.Delete(1);

            Assert.Null(_context.Superheroes.Find(1));
            Assert.Equal(Deleted, result);
        }

        [Fact]
        public async Task Given_non_existing_id_When_Delete_it_returns_not_found()
        {
            var result = await _repository.Delete(42);

            Assert.Equal(NotFound, result);
        }

        public void Dispose()
        {
            _connection.Dispose();
            _context.Dispose();
        }
    }
}
