using System;
using System.Threading;

namespace Lecture04
{
    public class RawSqlDemo
    {
        public static void Run(string connectionString)
        {
            using var raw = new RawSqlCharacterRepository(connectionString);

            raw.Reset();

            Read(raw);

            PrintHeader("READ('Turanga Leela')");

            var leela = raw.Read("Turanga Leela");
            Console.WriteLine(leela);

            PrintHeader("DELETE(2)");

            raw.Delete(2);

            Read(raw);

            PrintHeader("UPDATE - move Fry to Mars");

            var fry = raw.Read("Philip J. Fry");
            fry.Planet = "Mars";
            raw.Update(fry);

            Read(raw);
        }

        static void PrintHeader(string header)
        {
            Console.Write(new string('=', Console.WindowWidth));
            Console.WriteLine(header);
            Console.Write(new string('=', Console.WindowWidth));

            Thread.Sleep(TimeSpan.FromSeconds(1.5));
        }

        static void Read(RawSqlCharacterRepository raw)
        {
            PrintHeader("READ");

            foreach (var character in raw.Read())
            {
                Console.WriteLine(character);
            }
        }
    }
}
