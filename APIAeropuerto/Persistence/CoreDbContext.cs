using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence;

public class CoreDbContext : IdentityDbContext<UserPersistence,IdentityRole<Guid>,Guid>
{
    public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
    {
    }

    public DbSet<AirportPersistence> Airports { get; set; }
    public DbSet<InstallationsPersistence> Installations { get; set; }
    public DbSet<ServicesPersistence> Services { get; set; }
    public DbSet<ClientPersistence> Clients { get; set; }
    public DbSet<ClientServicesPersistence> ClientServices { get; set; }
    public DbSet<ShipPersistence> Ships { get; set; }
    public DbSet<FlightPersistence> Flights { get; set; }
    public DbSet<ServiceServicePersistence> RepairServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
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
        modelBuilder.Entity<UserPersistence>()
            .HasMany(x => x.UserRoles)
            .WithOne(x => x.UserPersistence)
            .HasForeignKey(k => k.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<UserPersistence>()
            .HasMany(x => x.UserClaims)
            .WithOne(x => x.UserPersistence)
            .HasForeignKey(k => k.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<RolePersistence>()
            .HasMany(x => x.UserRoles)
            .WithOne(x => x.RolePersistence)
            .HasForeignKey(k => k.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<RolePersistence>()
            .HasMany(x => x.RoleClaims)
            .WithOne(x => x.RolePersistence)
            .HasForeignKey(k => k.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<UserPersistence>()
            .HasMany(x => x.UserLogins)
            .WithOne(x => x.UserPersistence)
            .HasForeignKey(k => k.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<FlightPersistence>()
            .HasOne(x => x.AirportOrigin)
            .WithMany(x => x.OriginFlights)
            .HasForeignKey(k => k.IdAirportOrigin)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<FlightPersistence>()
            .HasOne(x => x.AirportDestination)
            .WithMany(x => x.DestinationFlights)
            .HasForeignKey(k => k.IdAirportDestination)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<FlightPersistence>()
            .HasOne(x => x.Client)
            .WithMany(x => x.Flights)
            .HasForeignKey(k => k.IdClient)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<FlightPersistence>()
            .HasOne(x => x.Ship)
            .WithMany(x => x.Flights)
            .HasForeignKey(k => k.IdShip)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<ServiceServicePersistence>()
            .HasKey(x => new { x.IdService1, x.IdService2 });

        modelBuilder.Entity<ServiceServicePersistence>()
            .HasOne(x => x.RepairService1)
            .WithMany(x => x.ServiceService)
            .HasForeignKey(pr => pr.IdService1)
            .OnDelete(DeleteBehavior.Restrict); // Para evitar la eliminación en cascada

        modelBuilder.Entity<ServiceServicePersistence>()
            .HasOne(x => x.RepairService2)
            .WithMany()
            .HasForeignKey(x => x.IdService2)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserPersistence>().HasOne(x => x.Client)
            .WithOne(x => x.User)
            .HasForeignKey<ClientPersistence>(x => x.IdUser);
    }
}