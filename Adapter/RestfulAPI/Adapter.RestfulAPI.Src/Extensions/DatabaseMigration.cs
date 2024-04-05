
using Adapter.CLI.Migration;

namespace Adapter.RestfulAPI.Src.Extensions;

public static class DatabaseMigration
{
    public static IServiceCollection MigrateDatabase(this IServiceCollection services, string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(
                $"Cannot start migration because connectionString is null: {nameof(connectionString)}.");
        }

        string[] arg = new[] { connectionString };
        
        var statusCode = Migration.Start(arg);
        
        if (statusCode != 0)
        {
            throw new Exception("Migration failed.");
        }

        return services;
    }
}