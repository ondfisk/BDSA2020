using Lecture04.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lecture04
{
    internal class SuperheroContextDesignTimeFactory : IDesignTimeDbContextFactory<SuperheroContext>
    {
        public SuperheroContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(typeof(Program).Assembly)
                .Build();

            var connectionString = configuration.GetConnectionString("Superheroes");

            var builder = new DbContextOptionsBuilder<SuperheroContext>();
            builder.UseSqlServer(connectionString);

            return new SuperheroContext(builder.Options);
        }
    }
}