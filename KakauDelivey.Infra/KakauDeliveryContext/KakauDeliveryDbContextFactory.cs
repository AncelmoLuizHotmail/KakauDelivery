using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace KakauDelivey.Infra.KakauDeliveryContext
{
    public class KakauDeliveryDbContextFactory : IDesignTimeDbContextFactory<KakauDeliveryDbContext>
    {
        public KakauDeliveryDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../KakauDelivery.API");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<KakauDeliveryDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new KakauDeliveryDbContext(optionsBuilder.Options);
        }
    }
}
