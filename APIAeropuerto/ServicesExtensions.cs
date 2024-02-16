using APIAeropuerto.Persistence;
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
}