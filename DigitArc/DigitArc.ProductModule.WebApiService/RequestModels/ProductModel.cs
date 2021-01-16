using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitArc.ProductModule.WebApiService.RequestModels
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
