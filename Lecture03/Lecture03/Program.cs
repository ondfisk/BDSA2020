using System;
using System.Linq;
using Lecture03.Models;
using System.IO;

namespace Lecture03
{
    public enum LogLevel { Verbose, Debug, Warning, Error }

    // public delegate void Logger(string message, LogLevel level);
    public delegate int Compute1(int x);
    public delegate int Compute2(int x, int y);
    public delegate bool Decide(int x);

    class Program
    {
        static void Main(string[] args)
        {
            // Logger logger = (message, level) =>
            // {
            //     Console.ForegroundColor = ConsoleColor.Blue;
            //     Console.WriteLine($"{level}: {message}");
            //     Console.ResetColor();
            // };

            // Func<int, int> compute;

            // var util = new Utility(logger);

            // Func<int, int> square = x => x * x;

            // Func<int, int, int> div = (x, y) => x / y;

            // Predicate<int> odd = x => x % 2 != 0;

            // Func<int, bool> odd2 = x => x % 2 != 0;

            // int div2 = (int x, int y) => x / y;

            // Console.WriteLine(util.Compute(square, 4));

            // Console.WriteLine(util.LogSafeCompute(div, 4, 2));

            // var random = new System.Random();

            // Func<double> rand = random.NextDouble;

            // Action<string> write = Console.Write;

            // Action<double> eatit = d => { };

            // Action g = () => Console.WriteLine("GGGG");

            // var name = "Bruce Wayne";

            // var split = name.SplitName();

            // Console.WriteLine(split);

            // Console.WriteLine("Clark Kent".SplitName());

            // System.Linq.Enumerable;

            // var repo = new Repository();

            // var cities = repo.Cities;

            // // cities.First(c => c.Name.StartsWith("G")).Print();

            // var heroes = repo.Superheroes2;

            // var man = heroes.Where(h => h.AlterEgo.EndsWith("man", StringComparison.InvariantCultureIgnoreCase));

            //man.Print();

            // heroes.OrderBy(h => h.GivenName)
            //       .ThenBy(h => h.Surname)
            //       .Print();

            // var query = "SELECT * FROM Heroes WHERE AlterEgo = 'Catwoman";

            // (from c in heroes
            //  orderby c.GivenName, c.Surname
            //  select c).Print();

            // var bruces = sorted.Where(c => c.GivenName == "Bruce");

            // bruces.Print();

            // var byFirstName = heroes.ToLookup(c => c.GivenName);

            //byFirstName["Bruce"].Print();

            // var linq = from h in repo.Superheroes
            //            join c in repo.Cities on h.CityId equals c.Id
            //            select new { h.AlterEgo, City = c.Name };

            // var extm = repo.Superheroes.Join(
            //            repo.Cities, h => h.CityId, c => c.Id, (h, c) => new { h.AlterEgo, City = c.Name });

            // hs.Print();

            // var nums = new[] {1,2,3,4,5};
            // nums.Print();

            // var repo = new Repository();
            // repo.Superheroes.Print();

            // repo.Superheroes.SelectMany(s => s.Powers).Distinct().OrderBy(c => c).Print();

            var text = File.ReadAllText("Hamlet.txt");

            var words = System.Text.RegularExpressions.Regex.Split(text, @"\P{L}+");

            var histogram = from w in words
                            group w by w.ToLower() into h
                            let c = h.Count()
                            orderby c descending
                            select new { Word = h.Key, Count = c };

            var byWord = histogram.ToDictionary(h => h.Word, h => h.Count);

            Console.WriteLine($"Hamlet appears in Hamlet {byWord["hamlet"]} times");
        }

        static int Div(int x, int y)
        {
            return x / y;
        }
    }

    public static class StringExtensions
    {
        public static (string, string) SplitName(this string name)
        {
            var split = name.Split(' ');

            return (split[0], split[1]);
        }
    }

    public class Utility
    {
        private readonly Action<string, LogLevel> _logger;

        public Utility(Action<string, LogLevel> logger)
        {
            _logger = logger;
        }

        public int Compute(Func<int, int> op, int x)
        {
            _logger.Invoke($"Invoking {op.Method.Name} with {x}", LogLevel.Debug);

            return op.Invoke(x);
        }

        public int Compute(Func<int, int, int> op, int x, int y)
        {
            _logger.Invoke($"Invoking {op.Method.Name} with {x} and {y}", LogLevel.Debug);

            return op.Invoke(x, y);
        }

        public int LogSafeCompute(Func<int, int, int> op, int x, int y)
        {
            _logger($"Invoking {op.Method.Name} with {x} and {y}", LogLevel.Debug);

            try
            {
                return op(x, y);
            }
            catch (Exception e)
            {
                _logger($"Exception: {e.Message}", LogLevel.Error);
                throw;
            }
        }
    }
}
