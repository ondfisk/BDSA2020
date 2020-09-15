using System;
using System.Data.SqlClient;
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

            var connectionString = configuration.GetConnectionString("ConnectionString");

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

            RawSqlDemo.Run(connectionString);
        }
    }
}
