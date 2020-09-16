using System;
using System.Data.SqlClient;
using System.Linq;
using Lecture04.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lecture04
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(typeof(Program).Assembly)
                .Build();

            // var connectionString = configuration.GetConnectionString("ConnectionString");

            // Console.WriteLine(connectionString.Substring(0, 10));

            // using var connection = new SqlConnection(connectionString);

            // connection.Open();

            // Console.Write("Input search string: ");

            // var searchString = Console.ReadLine();

            // var cmdText = $"SELECT * FROM Characters WHERE Name LIKE '%' + @SearchString + '%'";

            // using var command = new SqlCommand(cmdText, connection);
            // command.Parameters.AddWithValue("@SearchString", searchString);

            // using var reader = command.ExecuteReader();

            // while (reader.Read())
            // {
            //     Console.WriteLine(reader["Name"]);
            // }

            // RawSqlDemo.Run(connectionString);

            // var builder = new DbContextOptionsBuilder<FuturamaContext>();
            // builder.UseSqlServer(connectionString);
            // using var context = new FuturamaContext(builder.Options);

            // foreach (var character in context.Characters)
            // {
            //     Console.WriteLine(character.Name);
            // }

            // var amy = from c in context.Characters
            //           where c.Name == "Amy Wong"
            //           select new { c.Name, Actor = c.Actor.Name };

            // amy.Print();

            // var hermes = context.Characters.First(h => h.Name.Contains("Conrad"));

            // context.Characters.Remove(hermes);
            // context.SaveChanges();

            // var hubert = context.Characters.Find(7);

            // Console.WriteLine(hubert.Name);

            // hubert.Name = "Hubert Farnsworth";

            // context.SaveChanges();

            var connectionString = configuration.GetConnectionString("Superheroes");
            var builder = new DbContextOptionsBuilder<SuperheroContext>();
            builder.UseSqlServer(connectionString)
                   .UseLazyLoadingProxies();

            using var context = new SuperheroContext(builder.Options);

            // var superheroes = from h in context.Superheroes
            //                   select new
            //                   {
            //                       h.Name,
            //                       Powers = h.Powers.Select(p => p.Power.Name)
            //                   };

            // foreach (var hero in superheroes)
            // {
            //     Console.WriteLine(hero.Name);
            //     hero.Powers.Print();
            // }

            // context.Database.ExecuteSqlRaw("UPDATE Powers SET Name = 'Updated(' + Name + ')'");

            var heroes = context.Superheroes; //.Include(c => c.City);

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.City.Name);
            }

            // var heroes = from h in context.Superheroes
            //              orderby h.AlterEgo
            //              select new
            //              {
            //                  h.AlterEgo,
            //                  h.Name,
            //                  City = h.City.Name
            //              };

            // heroes.Print();
        }
    }
}
