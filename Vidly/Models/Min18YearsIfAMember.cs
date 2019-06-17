using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            /*
             * to make this code more maintainable and no use magic numbers we have two options: 1st is query the database and looking for the value, 2dn is create fields static and readonly attributes descripting the values in database, or in this case in our migration
             * other solution is declare a enum but we need to cast when we use custom validations 
             */
            if (customer.MembershipTypeId == MembershipType.Uknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return  new ValidationResult("Birthdate is required.");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            //when datetime is nullable attribute, to access the actual value is with value attribute: model.datetime-attribute.Value.*
            return (age <= 18 ? ValidationResult.Success : new ValidationResult("customer should be at least 18 yesr old to go on a membership. "));
        }
    }
}