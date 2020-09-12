using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static Lecture04.Entities.Gender;

namespace Lecture04.Entities
{
    public class SuperheroContext : DbContext
    {
        public DbSet<Superhero> Superheroes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<SuperheroPower> SuperheroPowers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Superheroes;Trusted_Connection=True;MultipleActiveResultSets=true";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperheroPower>().HasKey(c => new { c.SuperheroId, c.PowerId });

            modelBuilder.Entity<City>()
                        .HasMany(c => c.Superheroes)
                        .WithOne(s => s.City)
                        .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<City>()
                        .HasIndex(s => s.Name)
                        .IsUnique();

            modelBuilder.Entity<Power>()
                        .HasIndex(p => p.Name)
                        .IsUnique();

            var cities = new[] {
                new City { Id = 1, Name = "Metropolis" },
                new City { Id = 2, Name = "Gotham City" },
                new City { Id = 3, Name = "Atlantis" },
                new City { Id = 4, Name = "Themyscira" },
                new City { Id = 5, Name = "New York City" },
                new City { Id = 6, Name = "Central City" }
            };

            var cityDict = cities.ToDictionary(c => c.Name, c => c.Id);

            modelBuilder.Entity<City>().HasData(cities);

            var superheroes = new[] {
                new Superhero { Id = 1, Name = "Arthur Curry", AlterEgo = "Aquaman", Occupation = "King of Atlantis", Gender = Male, FirstAppearance = 1941, CityId = cityDict["Metropolis"] },
                new Superhero { Id = 2, Name = "Clark Kent", AlterEgo = "Superman", Occupation = "Reporter", Gender = Male, FirstAppearance = 1938, CityId = cityDict["Metropolis"] },
                new Superhero { Id = 3, Name = "Bruce Wayne", AlterEgo = "Batman", Occupation = "CEO of Wayne Enterprises", Gender = Male, FirstAppearance = 1939, CityId = cityDict["Gotham City"] },
                new Superhero { Id = 4, Name = "Diana", AlterEgo = "Wonder Woman", Occupation = "Amazon Princess", Gender = Female, FirstAppearance = 1941, CityId = cityDict["Themyscira"] },
                new Superhero { Id = 5, Name = "Hal Jordan", AlterEgo = "Green Lantern", Occupation = "Test pilot", Gender = Male, FirstAppearance = 1940, CityId = cityDict["New York City"] },
                new Superhero { Id = 6, Name = "Barry Allen", AlterEgo = "The Flash", Occupation = "Forensic scientist", Gender = Male, FirstAppearance = 1940, CityId = cityDict["Central City"] },
                new Superhero { Id = 7, Name = "Selina Kyle", AlterEgo = "Catwoman", Occupation = "Thief", Gender = Female, FirstAppearance = 1940, CityId = cityDict["Gotham City"] },
                new Superhero { Id = 8, Name = "Kate Kane", AlterEgo = "Batwoman", Occupation = "Thief", Gender = Female, FirstAppearance = 1956, CityId = cityDict["Gotham City"] },
                new Superhero { Id = 9, Name = "Kara Zor-El", AlterEgo = "Supergirl", Occupation = "Actress", Gender = Female, FirstAppearance = 1959, CityId = cityDict["New York City"] }
            };

            var superheroDict = superheroes.ToDictionary(h => h.AlterEgo, h => h.Id);

            modelBuilder.Entity<Superhero>().HasData(superheroes);

            var powers = new[]
            {
                new Power { Id = 1, Name = "ability to breathe underwater" },
                new Power { Id = 2, Name = "advanced technology" },
                new Power { Id = 3, Name = "alien technology" },
                new Power { Id = 4, Name = "brilliant deductive skills" },
                new Power { Id = 5, Name = "combat skill" },
                new Power { Id = 6, Name = "combat strategy" },
                new Power { Id = 7, Name = "control over sea life" },
                new Power { Id = 8, Name = "durability" },
                new Power { Id = 9, Name = "exceptional martial artist" },
                new Power { Id = 10, Name = "exceptional swimming ability" },
                new Power { Id = 11, Name = "flight" },
                new Power { Id = 12, Name = "force fields" },
                new Power { Id = 13, Name = "freeze breath" },
                new Power { Id = 14, Name = "gymnastic ability" },
                new Power { Id = 15, Name = "hard light constructs" },
                new Power { Id = 16, Name = "healing factor" },
                new Power { Id = 17, Name = "heat vision" },
                new Power { Id = 18, Name = "inexhaustible wealth" },
                new Power { Id = 19, Name = "instant weaponry" },
                new Power { Id = 20, Name = "intangibility" },
                new Power { Id = 21, Name = "intelligence" },
                new Power { Id = 22, Name = "invulnerability" },
                new Power { Id = 23, Name = "magic weaponry" },
                new Power { Id = 24, Name = "super speed" },
                new Power { Id = 25, Name = "super strength" },
                new Power { Id = 26, Name = "superhuman agility" },
                new Power { Id = 27, Name = "superhuman hearing" },
                new Power { Id = 28, Name = "x-ray vision" }
            };

            modelBuilder.Entity<Power>().HasData(
                powers
            );

            var powerDict = powers.ToDictionary(p => p.Name, p => p.Id);

            ICollection<SuperheroPower> convertToSuperheroPowers(string alterEgo, params string[] powers)
            {
                var projected = from p in powers
                                let superheroId = superheroDict[alterEgo]
                                let powerId = powerDict[p]
                                select new SuperheroPower { SuperheroId = superheroId, PowerId = powerId };

                return projected.ToList();
            }

            var superheroPowers = new[]
{
                convertToSuperheroPowers("Aquaman", new[] { "super strength", "durability", "control over sea life", "exceptional swimming ability", "ability to breathe underwater" }),
                convertToSuperheroPowers("Superman", new[] { "super strength", "flight", "invulnerability", "super speed", "heat vision", "freeze breath", "x-ray vision", "superhuman hearing", "healing factor" }),
                convertToSuperheroPowers("Batman", new[] { "exceptional martial artist", "combat strategy", "inexhaustible wealth", "brilliant deductive skills", "advanced technology" }),
                convertToSuperheroPowers("Wonder Woman", new[] { "super strength", "invulnerability", "flight", "combat skill", "combat strategy", "superhuman agility", "healing factor", "magic weaponry" }),
                convertToSuperheroPowers("Green Lantern", new[] { "hard light constructs", "instant weaponry", "force fields", "flight", "durability", "alien technology" }),
                convertToSuperheroPowers("The Flash", new[] { "super speed", "intangibility", "superhuman agility" }),
                convertToSuperheroPowers("Catwoman", new[] { "exceptional martial artist", "gymnastic ability", "combat skill" }),
                convertToSuperheroPowers("Batwoman", new[] { "exceptional martial artist", "combat strategy", "combat skill", "brilliant deductive skills", "intelligence", "advanced technology" }),
                convertToSuperheroPowers("Supergirl", new[] { "super strength", "flight", "invulnerability", "super speed", "heat vision", "freeze breath", "x-ray vision", "superhuman hearing", "healing factor" }),
            };

            modelBuilder.Entity<SuperheroPower>().HasData(superheroPowers.SelectMany(p => p));
        }
    }
}
