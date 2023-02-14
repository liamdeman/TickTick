using Microsoft.EntityFrameworkCore;
using TickTick.Models;

namespace TickTick.Data;

public class TickTickDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Speech> Speeches { get; set; }

    public TickTickDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>().ToTable(nameof(Songs));
        modelBuilder.Entity<Speech>().ToTable(nameof(Speeches));


        modelBuilder.Entity<Playlist>()
            .HasMany(x => x.Items)
            .WithOne(x => x.Playlist)
            .HasForeignKey(x => x.PlaylistId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Person>()
            .HasMany(x => x.Playlists)
            .WithOne(x => x.Person)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Person>()
            .ToTable(nameof(Persons), x => x.IsTemporal());
        base.OnModelCreating(modelBuilder);
    }
}