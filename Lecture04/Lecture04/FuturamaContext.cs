using Microsoft.EntityFrameworkCore;

namespace Lecture04
{
    public partial class FuturamaContext : DbContext
    {
        public FuturamaContext()
        {
        }

        public FuturamaContext(DbContextOptions<FuturamaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Planet).HasMaxLength(50);

                entity.Property(e => e.Species)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_Characters_Actors");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
