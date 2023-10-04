using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    //this is the class for custom validation to show an error message if the customer is 18 yrs of age when he chooses multiple membership
    //types
    public class Min18YrsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeID == MembershipType.Unknown|| customer.MembershipTypeID == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.DateOfBirth == null)
                return new ValidationResult("BirthDate is required!");

            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;

            return (age >= 18) ? 
                ValidationResult.Success : 
                new ValidationResult("Customer should be 18 years old to go on a membership!");
        }
    }
}