using DigitArc.ProductModule.Entities.Models;
using DigitArc.ProductModule.WebApiService.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitArc.ProductModule.Business.ValidationRules.FluentValidation
{
    public class ProductValidator: AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
