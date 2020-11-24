using Lecture12.Entities;
using System.Collections.Generic;
using static Lecture12.Entities.Gender;

namespace Lecture12.Models.Tests
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
                Powers = new List<Power>
                {
                    new Power { Name = "super strength" },
                    new Power { Name = "flight" },
                    new Power { Name = "invulnerability" },
                    new Power { Name = "super speed" },
                    new Power { Name = "heat vision" },
                    new Power { Name = "freeze breath" },
                    new Power { Name = "x-ray vision" },
                    new Power { Name = "superhuman hearing" },
                    new Power { Name = "healing factor" }
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
                Powers = new List<Power>
                {
                    new Power { Name = "exceptional martial artist" },
                    new Power { Name = "combat strategy" },
                    new Power { Name = "inexhaustible wealth" },
                    new Power { Name = "brilliant deductive skills" },
                    new Power { Name = "advanced technology" }
                }
            };

            context.Superheroes.AddRange(superman, batman);
            context.SaveChanges();
        }
    }
}
