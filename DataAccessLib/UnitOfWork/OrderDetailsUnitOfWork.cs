using DataAccessLib.Enitity;
using DataAccessLib.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
     public interface IProductUnitOfWork: IUnitOfWork
    {
        IProductRepository productRepository { get; }
        IRepository<ProductDetail> productDetail { get; }
        

    }

    public class ProductUnitOfWork : IProductUnitOfWork
    {
        private readonly ApplicationDBContext _databaseContext;
        private IProductRepository _productRepository;
        private IRepository<ProductDetail> _productDetail;
        public IProductRepository productRepository
        {
            get { return _productRepository = _productRepository ?? new ProductRepository(_databaseContext); }
        }

        public IRepository<ProductDetail> productDetail
        {
            get { return _productDetail = _productDetail ?? new Repository<ProductDetail>(_databaseContext); }
        }
     

        public ProductUnitOfWork(ApplicationDBContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public void Commit()
        {
            _databaseContext.SaveChanges();
        }

        public void Rollback()
        {
            _databaseContext.Dispose();
        }
    }
}
