using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Postgres.Config;

public static class PostgresDbConfig
{
    public static IServiceCollection AddPostgresDatabase(this IServiceCollection services,
        IConfiguration configuration, bool isProduction)
    {
        services.AddDbContext<PostgresDbContext>(options =>
        {
            options.UseNpgsql("Server=localhost; Port=5433; User ID=postgres; Password=example; Database=test; Pooling=true;");

            if (isProduction) return;

            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        return services;
    }
}