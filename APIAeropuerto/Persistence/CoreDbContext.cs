using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence;

public class CoreDbContext : DbContext
{
    public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
    {
    }

    public DbSet<AirportPersistence> Airports { get; set; }
    public DbSet<InstallationsPersistence> Installations { get; set; }
    public DbSet<ServicesPersistence> Services { get; set; }
    public DbSet<ClientPersistence> Clients { get; set; }
    public DbSet<ClientServicesPersistence> ClientServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ServicesPersistence>()
            .Property(s => s.Code)
            .ValueGeneratedNever();
        modelBuilder.Entity<InstallationsPersistence>()
            .HasOne(x => x.Airport)
            .WithMany(y => y.Installations)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ClientServicesPersistence>()
            .HasKey(x => new {x.IdClient, x.IdService});
        
        modelBuilder.Entity<ClientServicesPersistence>().HasOne(x => x.Client)
            .WithMany(x => x.ClientServices)
            .HasForeignKey(x => x.IdClient);
        modelBuilder.Entity<ClientServicesPersistence>().HasOne(x => x.Service)
            .WithMany(x => x.ClientServices)
            .HasForeignKey(x => x.IdService);
            
    }
}