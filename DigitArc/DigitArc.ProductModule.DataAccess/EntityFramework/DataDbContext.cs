using DigitArc.ProductModule.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;

namespace DigitArc.ProductModule.DataAccess.EntityFramework
{
    public class DataDbContext : DbContext
    {
       
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
    public class AppDbFactory : IDesignTimeDbContextFactory<DataDbContext>
    {
        public DataDbContext CreateDbContext(string[] args)
        {

            IConfiguration config = new ConfigurationBuilder()
                  .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                  .AddJsonFile("appsettings.json")
                  .Build();

            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<DataDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("DigitArc.ProductModule.DataAccess"));
            return new DataDbContext(optionsBuilder.Options);
        }
    }

}