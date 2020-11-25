using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Lecture12.Entities
{
    public interface ISuperheroContext
    {
        DbSet<Superhero> Superheroes { get; }
        DbSet<City> Cities { get; }
        DbSet<Power> Powers { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
