using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto;

public static class ServicesExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
    {
        _ = services.AddDbContextPool<CoreDbContext>(
            dbContextOptions => dbContextOptions
                .UseSqlServer(config.GetConnectionString("ApiConnection")));
    }
    
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<UserPersistence, RolePersistence>()
            .AddEntityFrameworkStores<CoreDbContext>()
            .AddDefaultTokenProviders();
    }
}   