using Lecture05.Entities;
using static Lecture05.Entities.Gender;

namespace Lecture05.Models.Tests
{
    public static class TestDataGenerator
    {
        public static void GenerateTestData(this SuperheroContext context)
        {
            var superman = new Superhero
            {
                Name = "Clark Kent",
                AlterEgo = "Superman",
                Occupation = "Reporter",
                Gender = Male,
                FirstAppearance = 1938,
                City = new City { Name = "Metropolis" },
                Powers = new[]
                {
                    new SuperheroPower { Power = new Power { Name = "super strength" } },
                    new SuperheroPower { Power = new Power { Name = "flight" } },
                    new SuperheroPower { Power = new Power { Name = "invulnerability" } },
                    new SuperheroPower { Power = new Power { Name = "super speed" } },
                    new SuperheroPower { Power = new Power { Name = "heat vision" } },
                    new SuperheroPower { Power = new Power { Name = "freeze breath" } },
                    new SuperheroPower { Power = new Power { Name = "x-ray vision" } },
                    new SuperheroPower { Power = new Power { Name = "superhuman hearing" } },
                    new SuperheroPower { Power = new Power { Name = "healing factor" } }
                }
            };

            var batman = new Superhero
            {
                Name = "Bruce Wayne",
                AlterEgo = "Batman",
                Occupation = "CEO of Wayne Enterprises",
                Gender = Male,
                FirstAppearance = 1939,
                City = new City { Name = "Gotham City" },
                Powers = new[]
                {
                    new SuperheroPower { Power = new Power { Name = "exceptional martial artist" } },
                    new SuperheroPower { Power = new Power { Name = "combat strategy" } },
                    new SuperheroPower { Power = new Power { Name = "inexhaustible wealth" } },
                    new SuperheroPower { Power = new Power { Name = "brilliant deductive skills" } },
                    new SuperheroPower { Power = new Power { Name = "advanced technology" } }
                }
            };

            context.Superheroes.AddRange(superman, batman);
            context.SaveChanges();
        }
    }
}