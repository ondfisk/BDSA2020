using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lecture08.Models.Bridge
{
    public interface ICharacterContext : IDisposable
    {
        DbSet<Character> Characters { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
