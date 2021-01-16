using DigitArc.ProductModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitArc.ProductModule.Business.Logic
{
    public interface IProductModuleservice
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
