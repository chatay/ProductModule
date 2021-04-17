using DigitArc.Core.EntityFramework;
using DigitArc.ProductModule.DataAccess.DatabaseLogic;
using DigitArc.ProductModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitArc.ProductModule.DataAccess.EntityFramework
{
    public class ProductDal: RepositoryBase<Product, DataDbContext>, IProductRepository
    {
        public ProductDal(DataDbContext context) : base(context)
        {

        }
    }
}
