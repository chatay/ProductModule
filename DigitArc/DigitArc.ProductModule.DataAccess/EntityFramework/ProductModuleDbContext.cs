using DigitArc.ProductModule.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
}
