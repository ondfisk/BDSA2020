using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static Lecture10.Entities.Gender;

namespace Lecture10.Entities
{
    public class SuperheroContext : DbContext, ISuperheroContext
    {
        public DbSet<Superhero> Superheroes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<SuperheroPower> SuperheroPowers { get; set; }

        public SuperheroContext(DbContextOptions<SuperheroContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Superhero>()
                .Property(e => e.Gender)
                .HasConversion(
                    e => e.ToString(),
                    e => Enum.Parse<Gender>(e));

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

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Metropolis" },
                new City { Id = 2, Name = "Gotham City" },
                new City { Id = 3, Name = "Atlantis" },
                new City { Id = 4, Name = "Themyscira" },
                new City { Id = 5, Name = "New York City" },
                new City { Id = 6, Name = "Central City" }
            );

            static string portraitUrl(string name) => $"https://ondfisk.blob.core.windows.net/superheroes/{name}-portrait.jpg";

            static string backgroundUrl(string name) => $"https://ondfisk.blob.core.windows.net/superheroes/{name}-background.jpg";

            modelBuilder.Entity<Superhero>().HasData(
                new Superhero { Id = 1, Name = "Arthur Curry", AlterEgo = "Aquaman", Occupation = "King of Atlantis", Gender = Male, FirstAppearance = 1941, CityId = 1, PortraitUrl = portraitUrl("aquaman"), BackgroundUrl = backgroundUrl("aquaman") },
                new Superhero { Id = 2, Name = "Clark Kent", AlterEgo = "Superman", Occupation = "Reporter", Gender = Male, FirstAppearance = 1938, CityId = 1, PortraitUrl = portraitUrl("superman"), BackgroundUrl = backgroundUrl("superman") },
                new Superhero { Id = 3, Name = "Bruce Wayne", AlterEgo = "Batman", Occupation = "CEO of Wayne Enterprises", Gender = Male, FirstAppearance = 1939, CityId = 2, PortraitUrl = portraitUrl("batman"), BackgroundUrl = backgroundUrl("batman") },
                new Superhero { Id = 4, Name = "Diana", AlterEgo = "Wonder Woman", Occupation = "Amazon Princess", Gender = Female, FirstAppearance = 1941, CityId = 4, PortraitUrl = portraitUrl("wonder-woman"), BackgroundUrl = backgroundUrl("wonder-woman") },
                new Superhero { Id = 5, Name = "Hal Jordan", AlterEgo = "Green Lantern", Occupation = "Test pilot", Gender = Male, FirstAppearance = 1940, CityId = 5, PortraitUrl = portraitUrl("green-lantern"), BackgroundUrl = backgroundUrl("green-lantern") },
                new Superhero { Id = 6, Name = "Barry Allen", AlterEgo = "The Flash", Occupation = "Forensic scientist", Gender = Male, FirstAppearance = 1940, CityId = 6, PortraitUrl = portraitUrl("the-flash"), BackgroundUrl = backgroundUrl("the-flash") },
                new Superhero { Id = 7, Name = "Selina Kyle", AlterEgo = "Catwoman", Occupation = "Thief", Gender = Female, FirstAppearance = 1940, CityId = 2, PortraitUrl = portraitUrl("catwoman"), BackgroundUrl = backgroundUrl("catwoman") },
                new Superhero { Id = 8, Name = "Kate Kane", AlterEgo = "Batwoman", Occupation = "Thief", Gender = Female, FirstAppearance = 1956, CityId = 2, PortraitUrl = portraitUrl("batwoman"), BackgroundUrl = backgroundUrl("batwoman") },
                new Superhero { Id = 9, Name = "Kara Zor-El", AlterEgo = "Supergirl", Occupation = "Actress", Gender = Female, FirstAppearance = 1959, CityId = 5, PortraitUrl = portraitUrl("supergirl"), BackgroundUrl = backgroundUrl("supergirl") }
            );

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

            var dictionary = powers.ToDictionary(p => p.Name, p => p.Id);

            ICollection<SuperheroPower> convertToSuperheroPowers(int superheroId, params string[] powers)
            {
                var projected = from p in powers
                                let powerId = dictionary[p]
                                select new SuperheroPower { SuperheroId = superheroId, PowerId = powerId };

                return projected.ToList();
            }

            var superheroPowers = new[]
{
                convertToSuperheroPowers(1, new[] { "super strength", "durability", "control over sea life", "exceptional swimming ability", "ability to breathe underwater" }),
                convertToSuperheroPowers(2, new[] { "super strength", "flight", "invulnerability", "super speed", "heat vision", "freeze breath", "x-ray vision", "superhuman hearing", "healing factor" }),
                convertToSuperheroPowers(3, new[] { "exceptional martial artist", "combat strategy", "inexhaustible wealth", "brilliant deductive skills", "advanced technology" }),
                convertToSuperheroPowers(4, new[] { "super strength", "invulnerability", "flight", "combat skill", "combat strategy", "superhuman agility", "healing factor", "magic weaponry" }),
                convertToSuperheroPowers(5, new[] { "hard light constructs", "instant weaponry", "force fields", "flight", "durability", "alien technology" }),
                convertToSuperheroPowers(6, new[] { "super speed", "intangibility", "superhuman agility" }),
                convertToSuperheroPowers(7, new[] { "exceptional martial artist", "gymnastic ability", "combat skill" }),
                convertToSuperheroPowers(8, new[] { "exceptional martial artist", "combat strategy", "combat skill", "brilliant deductive skills", "intelligence", "advanced technology" }),
                convertToSuperheroPowers(9, new[] { "super strength", "flight", "invulnerability", "super speed", "heat vision", "freeze breath", "x-ray vision", "superhuman hearing", "healing factor" }),
            };

            modelBuilder.Entity<SuperheroPower>().HasData(superheroPowers.SelectMany(p => p));
        }
    }
}
