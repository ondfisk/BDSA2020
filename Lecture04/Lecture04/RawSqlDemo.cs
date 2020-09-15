using System;

namespace Lecture04
{
    public class RawSqlDemo
    {
        public static void Run(string connectionString)
        {
            using var raw = new RawSqlCharacterRepository(connectionString);

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
            Console.ReadKey();
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
