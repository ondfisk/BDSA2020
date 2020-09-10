using System;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lecture04
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SuperheroContext())
            {
                // var batman = new Superhero
                // {
                //     Name = "Bruce Wayne",
                //     AlterEgo = "Batman",
                //     Occupation = "CEO of Wayne Enterprises",
                //     FirstAppearance = 1938
                // };

                // context.Superheroes.Add(batman);

                // context.SaveChanges();

                // var batman = context.Superheroes.Find(2);
                // batman.CityId = 1;
                // context.SaveChanges();

                // var batman = context.Superheroes.Find(1);
                // context.Superheroes.Remove(batman);
                // context.SaveChanges();

                // var gotham = context.Cities.Find(1);
                // context.Cities.Remove(gotham);
                // context.SaveChanges();

                // var gothamHeroes = from h in context.Superheroes
                //                    where h.City.Name == "Gotham City"
                //                    select new { h.Name, h.AlterEgo };

                // foreach (var hero in gothamHeroes)
                // {
                //     Console.WriteLine(hero);
                // }

                var powers = from h in context.Powers
                             select new
                             {
                                 h.Name,
                                 Heroes = h.Superheroes.Select(s => s.Superhero.AlterEgo)
                             };

                // foreach (var power in powers)
                // {
                //     Console.WriteLine(power.Name);

                //     foreach (var hero in power.Heroes)
                //     {
                //         Console.WriteLine($"- {hero}");
                //     }

                //     Console.WriteLine();
                // }

                // var heroes = from h in context.Superheroes
                //              orderby h.AlterEgo
                //              select h;

                // var grouped = from h in heroes
                //               group h by new { h.CityId, City = h.City.Name } into c
                //               select new
                //               {
                //                   c.Key.City,
                //                   Count = c.Count()
                //               };

                // foreach (var group in grouped)
                // {
                //     Console.WriteLine(group);
                // }

                var hero = context.Superheroes.Include(s => s.City).Include(c => c.Powers).ThenInclude(c => c.Power).FirstOrDefault();

                //catwoman.City.Name = "Gotham City";

                Console.WriteLine(string.Join(", ", hero.Powers.Select(s => s.Power.Name)));
                //context.SaveChanges();
            }
        }

        static void OldMain(string[] args)
        {
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Futurama;Trusted_Connection=True;MultipleActiveResultSets=true";

            Console.Write("Enter search string: ");
            var searchString = Console.ReadLine();

            var cmdText = "SELECT Name FROM Characters WHERE Name LIKE '%' + @SearchString + '%'";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(cmdText, connection))
            {
                command.Parameters.AddWithValue("@SearchString", searchString);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["Name"]);
                }
            }

            RawSqlDemo.Run();
        }
    }
}
