using DigitArc.ProductModule.Business.Logic;
using DigitArc.ProductModule.Entities.Models;
using DigitArc.ProductModule.WebApiService.Models;
using DigitArc.ProductModule.WebApiService.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitArc.ProductModule.WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductModuleservice productModuleservice;

        public ProductController(IProductModuleservice productModuleservice)
        {
            this.productModuleservice = productModuleservice;
        }
        [HttpGet]
        public IActionResult Get()
        {
            ServiceResponse<Product> response = new ServiceResponse<Product>
            {
                Entities = productModuleservice.GetAll(),
                IsSuccessfull = true
            };
            response.EntitiesCount = response.Entities.Count();
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ProductModel model )
        {
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price
            };
            productModuleservice.Add(product);

            ServiceResponse<Product> response = new ServiceResponse<Product>
            {
                Entity = product,
                IsSuccessfull = true
            };
            return Ok(response);
        }
        [HttpPut]
        public IActionResult Put(int id, [FromBody] ProductModel model)
        {
            ServiceResponse<Product> response = new ServiceResponse<Product>();

            var product = productModuleservice.GetById(id);

            if (product == null)
            {
                response.IsSuccessfull = false;
                response.Errors.Add("product not found");
                return NotFound(response);
            }

            product.Name = model.Name;
            product.Price = model.Price;
            response.IsSuccessfull = true;

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null) return BadRequest();

            ServiceResponse<Product> response = new ServiceResponse<Product>();

            var product = productModuleservice.GetById(id);

            if (product == null) return NotFound();

            productModuleservice.Delete(product);
            response.IsSuccessfull = true;

            return Ok(response);
        }
    }
}
