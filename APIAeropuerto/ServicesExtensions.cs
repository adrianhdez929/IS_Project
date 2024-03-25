using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
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
    
    public static void ConfigureDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var connectionStrings = services.GetRequiredService<IConfiguration>().GetConnectionString("FirstConnection");
            using (var connection = new SqlConnection(connectionStrings))
            {
                connection.Open();
                using (var command = new SqlCommand("IF DB_ID('Aeropuerto_DB') IS NULL CREATE DATABASE Aeropuerto_DB;", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            var context = services.GetRequiredService<CoreDbContext>();
            context.Database.Migrate();
        }
        catch (Exception)
        {
            throw new Exception("An error occurred while creating the database.");
        }
    }
}   