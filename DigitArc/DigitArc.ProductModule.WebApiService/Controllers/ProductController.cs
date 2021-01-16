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
        public IActionResult Post([FromBody] ProductModel model )
        {
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price
            };
            productModuleservice.Add(product);
            return Ok(product1);
        }
    }
}
