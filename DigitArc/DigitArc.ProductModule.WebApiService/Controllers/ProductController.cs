using DigitArc.ProductModule.Business.Logic;
using DigitArc.ProductModule.Entities.Models;
using DigitArc.ProductModule.WebApiService.Models;
using DigitArc.ProductModule.WebApiService.RequestModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DigitArc.ProductModule.WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductModuleservice productModuleservice;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductModuleservice productModuleservice, IWebHostEnvironment _webHostEnvironment)
        {
            this.productModuleservice = productModuleservice;
            this._webHostEnvironment = _webHostEnvironment;
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
        public async Task<IActionResult> Post([FromForm] ProductModel model)
        {
            try
            {
                var fileUploadResult = "";
                if (model.file.Length > 0)
                {
                    fileUploadResult = await FileUpload(model);
                }
                Product product = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    ImagePath = fileUploadResult
                };

                productModuleservice.Add(product);
                productModuleservice.Save();


                ServiceResponse<Product> response = new ServiceResponse<Product>
                {
                    Entity = product,
                    IsSuccessfull = true
                };

                return Ok(new { count = 1, path = fileUploadResult, response });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] ProductModel model)
        {
            try
            {
                ServiceResponse<Product> response = new ServiceResponse<Product>();

                var product = productModuleservice.GetById(id);
                if (product == null)
                {
                    response.IsSuccessfull = false;
                    response.Errors.Add("product not found");
                    return NotFound(response);
                }

                int result = DeleteImageFile(product.ImagePath, product);
                if (result != Constants.SUCCESS) return StatusCode(500);

                var fileUploadResult = "";
                if (model.file.Length > 0)
                {
                    fileUploadResult = await FileUpload(model);
                }

                product.Name = model.Name;
                product.Price = model.Price;
                product.ImagePath = fileUploadResult;
                productModuleservice.Update(product);

                response.IsSuccessfull = true;

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == null) return BadRequest();

                ServiceResponse<Product> response = new ServiceResponse<Product>();

                var product = productModuleservice.GetById(id);

                if (product == null) return NotFound();

                int result =  DeleteImageFile(product.ImagePath, product);

                if (result == Constants.SUCCESS)
                {
                    productModuleservice.Delete(product);
                    response.IsSuccessfull = true;
                }
                else response.IsSuccessfull = false;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        private async Task<string> FileUpload(ProductModel model)
        {
            if (!Directory.Exists(_webHostEnvironment + "\\uploads\\"))
            {
                Directory.CreateDirectory(_webHostEnvironment + "\\uploads\\");
            }
            using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment + "\\uploads\\" + model.file.FileName))
            {
                await model.file.CopyToAsync(fileStream);
                fileStream.Flush();
                return _webHostEnvironment.ContentRootPath + "\\" + _webHostEnvironment + "\\uploads\\" + model.file.FileName;
            }
        }

        private int DeleteImageFile(string filePath, Product product)
        {
            var imagePath = product.ImagePath;

            var webRoot = _webHostEnvironment.ToString();
            var file = System.IO.Path.Combine(webRoot,imagePath);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(filePath);

                return Constants.SUCCESS;
            }
            return Constants.FAIL;

        }
    }
}
