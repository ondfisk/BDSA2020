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
        }
    }
}
