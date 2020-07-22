using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccessLib.Enitity;
namespace DataAccessLib.Repository
{
  public  class ProductDetailsRepository : Repository<ProductDetail>
    {
        private ApplicationDBContext _context;

        public ProductDetailsRepository(ApplicationDBContext context) : base(context) {

            this._context = context;
        }

       
    }
}
