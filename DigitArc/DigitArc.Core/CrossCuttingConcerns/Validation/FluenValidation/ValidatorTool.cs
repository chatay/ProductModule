using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace DigitArc.Core.CrossCuttingConcerns.Validation.FluenValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);

            if (result.Errors.Count > 0) { throw new ValidationException(result.Errors); };
        }
    }
}
