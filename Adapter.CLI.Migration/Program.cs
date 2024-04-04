using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;

namespace Adapter.CLI.Migration;

internal static class Program
{
    private static string? GetConnectionString(string[] args)
    {
        var passedConnectionString = args.FirstOrDefault();


        if (!string.IsNullOrEmpty(passedConnectionString))
        {
            return passedConnectionString;
        }

        var builder = new ConfigurationBuilder()
            .SetBasePath(GetProjectDirectory())
            .AddJsonFile("appSettings.json", optional: false);

        IConfiguration conf = builder.Build();

        var connectionString = conf.GetConnectionString("RootConnection");

        Console.WriteLine($"This Connectionstring: {connectionString}");

        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("Connection string not found in appSettings.json, application will now exit.");
            return null;
        }

        return conf.GetConnectionString("RootConnection");
    }

    private static int Main(string[] args)
    {
        Console.WriteLine(@"    _        _           _   _                   ____                        ");
        Console.WriteLine(@"   / \   ___(_) __ _    | \ | | __ __      __   |  _ \ __ __      __ __ _ __ ");
        Console.WriteLine(@"  / _ \ / __| |/ _` |   |  \| |/ _ \ \ /\ / /   | |_) / _ \ \ /\ / / _ \ '__|");
        Console.WriteLine(@" / ___ \\__ \ | (_| |   | |\  |  __/\ V  V /    |  __/ (_) \ V  V /  __/ |   ");
        Console.WriteLine(@"/_/   \_\___/_|\__,_|   |_| \_|\___| \_/\_/     |_|   \___/ \_/\_/ \___|_|   ");
        Console.WriteLine("");

        string? connectionString = GetConnectionString(args);

        if (string.IsNullOrEmpty(connectionString))
        {
            return -1;
        }

        // If you want your application to create the database for you
        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        var upgradeEngine =
            DeployChanges
                .To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

        var result = upgradeEngine.PerformUpgrade();

        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            Console.ResetColor();
#if DEBUG
            Console.ReadLine();
#endif
            return 1;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Success!");
        Console.ResetColor();
        return 0;
    }

    static string GetProjectDirectory()
    {
        // Get the directory of the currently executing assembly
        string assemblyLocation = Assembly.GetExecutingAssembly().Location;

        // Get the directory of the assembly (which is the bin folder)
        string? assemblyDirectory = Path.GetDirectoryName(assemblyLocation);

        // Navigate up two levels to get to the project directory
        string projectDirectory = Directory.GetParent(assemblyDirectory!)!.Parent!.FullName;

        projectDirectory = string.Join("/", projectDirectory.Split("/").SkipLast(1));

        return projectDirectory;
    }
}