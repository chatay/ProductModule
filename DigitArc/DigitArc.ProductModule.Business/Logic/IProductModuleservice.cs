using DigitArc.ProductModule.Entities.Models;
using System.Collections.Generic;

namespace DigitArc.ProductModule.Business.Logic
{
    public interface IProductModuleservice
    {
        List<Product> GetAll();

        void Add(Product product);
        Product GetById(int Id);

        void Update(Product product);

        void Delete(Product product);
    }
}