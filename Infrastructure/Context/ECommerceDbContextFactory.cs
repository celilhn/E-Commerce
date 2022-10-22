using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using Application.Utilities;

namespace Infrastructure.Context
{

    public class ECommerceDbContextFactory : IDesignTimeDbContextFactory<MTriggerDbContext>
    {
        private IConfiguration configuration;
        public MTriggerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MTriggerDbContext>();

            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Path.Combine(folderPath, "sharedsettings.json"), false, true)
                .AddJsonFile(Path.Combine(folderPath, "appsettings.json"), false, true)
                .AddEnvironmentVariables()
                .Build();
            AppUtilities.AppUtilitiesConfigure(configuration);

            optionsBuilder.UseSqlServer(AppUtilities.GetConfigurationValue("DBConnectionText"));
            return new MTriggerDbContext(optionsBuilder.Options);
        }
    }
}
