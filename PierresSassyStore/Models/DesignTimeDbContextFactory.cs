
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PierresSassyStore.Models
{
    public class PierresSassyStoreContextFactory : IDesignTimeDbContextFactory<PierresSassyStoreContext>
    {

        PierresSassyStoreContext IDesignTimeDbContextFactory<PierresSassyStoreContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PierresSassyStoreContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new PierresSassyStoreContext(builder.Options);
        }
    }
}