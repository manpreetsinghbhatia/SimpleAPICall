using Microsoft.EntityFrameworkCore;
using System;
using DataAccessLib.Enitity;
using System.Configuration;
using DataAccessLib.Initialition;

namespace DataAccessLib
{
    public class ApplicationDBContext: DbContext
    {
      

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
    : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //# http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UsePostgreSql(@"host=server;database=test;user id=postgres;");
            // optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["BloggingDatabase"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    modelBuilder.Seed();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }
    }
}
