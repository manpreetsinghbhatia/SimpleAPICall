using DataAccessLib.Enitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
 
using System.Text;

namespace DataAccessLib.Initialition
{
    class SeedData
    {
    }
    public static  class OrderDBInitializer 
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = Guid.NewGuid(),
                    Name = "Bat",
                    Price = 100.00,
                    Maker= "SS"
                   
                },
                 new Product
                 {
                     ID = Guid.NewGuid(),
                     Name = "Ball",
                     Price = 6.00,
                     Maker = "SS"

                 },
                  new Product
                  {
                      ID= Guid.NewGuid(),
                      Name = "Gloves",
                      Price = 10.00,
                      Maker = "SS"

                  }

            );
            modelBuilder.Entity<Order>().HasData(
                new Order { ID = Guid.NewGuid(), OrderDate = System.DateTime.Now, Total = 200.00 },
                new Order { ID = Guid.NewGuid(), OrderDate = System.DateTime.Now, Total = 150.00 },
               new Order { ID = Guid.NewGuid(), OrderDate = System.DateTime.Now, Total = 50.00 }
            );
        }
    }
}
