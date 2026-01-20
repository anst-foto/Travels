using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Travels.DAL;

public class DataBaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
{
    public DataBaseContext CreateDbContext(string[] args)
    {
        var connectionString = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Migrations.json")
            .Build()
            .GetConnectionString("Test");

        var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
        var options = optionsBuilder.UseNpgsql(connectionString).Options;

        return new DataBaseContext(options);
    }

    public static DataBaseContext CreateDbContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
        var options = optionsBuilder.UseNpgsql(connectionString).Options;

        return new DataBaseContext(options);
    }
}
