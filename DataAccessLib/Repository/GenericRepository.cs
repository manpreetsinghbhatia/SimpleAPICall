using DataAccessLib.Enitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLib.Repository
{
    public interface IRepository<T> where T : BaseEnitity
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }


    public class Repository<T> : IRepository<T> where T : BaseEnitity
    {
        protected readonly ApplicationDBContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(ApplicationDBContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
       // public abstract T GetById(Guid id);
         
        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entities.Add(entity);
            
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
           
        }
        public virtual void Delete(Guid id)
        {
           // throw new NotImplementedException();
            if (id == null) throw new ArgumentNullException("entity");

            T entity = entities.SingleOrDefault(s => s.ID == id);
            entities.Remove(entity);

        }

        public virtual T GetById(Guid id)
        {
            return entities.SingleOrDefault(s => s.ID == id);
        }
    }
     
}
