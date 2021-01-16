﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DigitArc.ProductModule.Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name{ get; set; }
        public decimal Price { get; set; }
        public int ImageId { get; set; }
    }
}
