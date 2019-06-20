using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.CustomValidations
{
    public class Validate20Stock : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie) validationContext.ObjectInstance;
            if (movie.Stock > 0 && movie.Stock <= 20)
            {
                return  ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Enter range between 1 and 20");
            }
        }
    }
}