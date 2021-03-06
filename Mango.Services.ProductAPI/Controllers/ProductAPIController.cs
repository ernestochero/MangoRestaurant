using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Models.Dtos;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    // GET
    [Route("api/products")]
    public class ProductApiController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductApiController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }
        
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos =
                    await _productRepository.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    e.ToString()
                };
            }
            return _response;
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto =
                    await _productRepository.GetProductById(id);
                _response.Result = productDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    e.ToString()
                };
            }
            return _response;
        }
        
        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model =
                    await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    e.ToString()
                };
            }
            return _response;
        }
        
        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model =
                    await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    e.ToString()
                };
            }
            return _response;
        }
        
        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool result =
                    await _productRepository.DeleteProduct(id);
                _response.Result = result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    e.ToString()
                };
            }
            return _response;
        }
        
        
    }
}