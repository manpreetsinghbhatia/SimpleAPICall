using DataAccessLib.Enitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLib.Repository
{

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(Guid productId);
        void InsertProduct(Product product);
        void DeleteProduct(Guid productId);
        void UpdateProduct(Product product);
        void Save();
    }
   public class ProductRepository : IProductRepository
    {
        private ApplicationDBContext context;

        public ProductRepository(ApplicationDBContext ApplicationDBContext) 
        {
            this.context = ApplicationDBContext;
        }
        public void DeleteProduct(Guid productId)
        {
            Product product = this.context.Products.Find(productId);
            this.context.Products.Remove(product);
        }

        public Product GetProductByID(Guid productId)
        {
            return this.context.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.context.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            this.context.Products.Add(product);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
        }
    }
}
