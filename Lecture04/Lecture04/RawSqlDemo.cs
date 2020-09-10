using System;

namespace Lecture04
{
    public class RawSqlDemo
    {
        public static void Run()
        {
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Futurama;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (var raw = new RawSql(connectionString))
            {
                Read(raw);

                PrintHeader("READ('Turanga Leela')");

                var leela = raw.Read("Turanga Leela");
                Console.WriteLine(leela);

                PrintHeader("DELETE(2)");

                raw.Delete(2);

                Read(raw);

                PrintHeader("UPDATE - move fry to Mars");

                var fry = raw.Read("Philip J. Fry");
                fry.Planet = "Mars";
                raw.Update(fry);

                Read(raw);
            }
        }

        static void PrintHeader(string header)
        {
            Console.Write(new string('=', Console.WindowWidth));
            Console.WriteLine(header);
            Console.Write(new string('=', Console.WindowWidth));
        }

        static void Read(RawSql raw)
        {
            PrintHeader("READ");

            foreach (var character in raw.Read())
            {
                Console.WriteLine(character);
            }
        }
    }
}
