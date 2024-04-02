using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adapter.Database.Postgres.Config;

public static class PostgresDbConfig
{
    public static IServiceCollection AddPostgresDatabase(this IServiceCollection services,
        IConfiguration configuration, bool isProduction)
    {
        services.AddDbContext<PostgresDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            if (isProduction) return;

            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        return services;
    }
}