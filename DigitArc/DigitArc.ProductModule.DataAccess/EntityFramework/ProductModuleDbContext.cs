using DigitArc.ProductModule.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;

namespace DigitArc.ProductModule.DataAccess.EntityFramework
{
    public class ProductModuleDbContext : DbContext
    {
       
        public ProductModuleDbContext(DbContextOptions<ProductModuleDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
    }
    public class AppDbFactory : IDesignTimeDbContextFactory<ProductModuleDbContext>
    {
        public ProductModuleDbContext CreateDbContext(string[] args)
        {

            IConfiguration config = new ConfigurationBuilder()
                  .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                  .AddJsonFile("appsettings.json")
                  .Build();

            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<ProductModuleDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("DigitArc.ProductModule.DataAccess"));
            return new ProductModuleDbContext(optionsBuilder.Options);

            //var builder = new ConfigurationBuilder();
            //var configuration = builder.Build();

            ////var connectionString = AppConfig.GetConnectionString();
            //ConnectionString.Value = configuration["DefaultConnection"];
            //var connStr = Configuration.
            //               .GetSection("DefaultConnection")["ConnectionString"];

            //var optionsBuilder = new DbContextOptionsBuilder<ProductModuleDbContext>();
            //optionsBuilder.UseSqlServer(ConnectionString.Value);

            //return new ProductModuleDbContext(optionsBuilder.Options);
        }
    }

}