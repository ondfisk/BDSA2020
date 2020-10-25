using System;
using System.Security.Cryptography;
using System.Text;

namespace Lecture08.Models.Strategy
{
    public class Strategy
    {
        public static void Run()
        {
            Console.WriteLine("Input string to hash:");
            var value = Console.ReadLine();

            Console.WriteLine("Choose a hash strategy:");
            Console.WriteLine("1: MD5");
            Console.WriteLine("2: SHA1");
            Console.WriteLine("3: SHA256");
            Console.WriteLine("4: SHA512");

            Console.Write("Input number: ");
            var key = Console.ReadKey();
            Console.WriteLine();

            string hash;

            switch (key.KeyChar)
            {
                case '1':
                    hash = Hash(MD5.Create(), value);
                    break;
                case '2':
                    hash = Hash(SHA1.Create(), value);
                    break;
                case '3':
                    hash = Hash(SHA256.Create(), value);
                    break;
                case '4':
                    hash = Hash(SHA512.Create(), value);
                    break;

                default:
                    Console.WriteLine("Unknown algorithm");
                    return;
            }

            Console.WriteLine($"The hashed value is: {hash}");

            Console.Write("Try again [y/n] ");

            key = Console.ReadKey();
            Console.WriteLine();

            if (key.KeyChar == 'y')
            {
                Run();
            }
        }

        public static string Hash(HashAlgorithm algorithm, string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);

            var hash = algorithm.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}
