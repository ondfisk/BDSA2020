using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Lecture08.App
{
    public class StrategyContainer
    {
        // serviceCollection.AddTransient<HashAlgorithm>(_ => MD5.Create());
        // serviceCollection.AddTransient<HashAlgorithm>(_ => SHA1.Create());
        // serviceCollection.AddTransient<HashAlgorithm>(_ => SHA256.Create());

        public static void Run()
        {
            Console.WriteLine("Input string to hash:");
            Console.ForegroundColor = ConsoleColor.Green;
            var value = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Choose a hash strategy:");

            var container = IoCContainer.Container;

            var algorithms = container.GetServices<HashAlgorithm>().ToList();

            for (var i = 0; i < algorithms.Count; i++)
            {
                var algorithm = algorithms[i];

                Console.WriteLine($"{i}: {GetName(algorithm)}");
            }

            Console.Write("Input number: ");
            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out var index))
            {
                Console.WriteLine();

                var chosenAlgorithm = algorithms[index];

                var hash = Hash(chosenAlgorithm, value);

                Console.Write("The hashed value is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(hash);
                Console.ResetColor();
            }

            Console.Write("Try again [y/n]: ");

            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.KeyChar == 'y')
            {
                Run();
            }
        }

        private static string GetName(HashAlgorithm algorithm)
        {
            return algorithm.ToString().Split('.').Last().Split('+').First();
        }

        public static string Hash(HashAlgorithm algorithm, string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);

            var hash = algorithm.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}
