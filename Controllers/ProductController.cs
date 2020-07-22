using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViewModel = SimpleAPICall.ViewModels;
using DataModel = DataAccessLib.Enitity;
using DataAccessLib.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAPICall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IProductUnitOfWork _unitOfWork;
        public ProductController(IMapper mapper, IProductUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            this._unitOfWork = unitOfWork; 
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ViewModel.Product> Get()
        {
            IEnumerable<DataModel.Product> products = _unitOfWork.productRepository.GetProducts();
           return _mapper.Map<IEnumerable<ViewModel.Product>>(products);
            //return new string[] { "value1", "value2" };
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ViewModel.Product Get(Guid id)
        {
          DataModel.Product product =  _unitOfWork.productRepository.GetProductByID(id);
            return _mapper.Map<ViewModel.Product>(product);


        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("CreateDummy")]
        public void CreateDummy()
        {
            ViewModel.Product product = new ViewModel.Product() { ID = Guid.NewGuid(), Maker="Yonex", Name="BatMinton",Price=120.00};
            ViewModel.ProductDetail details = new ViewModel.ProductDetail()
            {
                ID = Guid.NewGuid(),
                Description = "Awesome Badminton",
                ProductID = product.ID
            };

            try
            {
                DataModel.Product dbProd = _mapper.Map<DataModel.Product>(product);
                DataModel.ProductDetail dbProdDetail = _mapper.Map<DataModel.ProductDetail>(details);
                _unitOfWork.productRepository.InsertProduct(dbProd);
                _unitOfWork.productDetail.Insert(dbProdDetail);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error when creating uow transaction, thereby reverting back. Error: {}", ex.Message);
                _unitOfWork.Rollback();
               // return Task.FromResult(new Author());
            }

          //  return _unitOfWork.AuthorRepository.GetByName(fyodor.Name);
        }
    }
    
}
