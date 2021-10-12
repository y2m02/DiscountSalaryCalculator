using System;
using System.ComponentModel.DataAnnotations;

namespace SalaryDiscountCalculatorApi.Helpers
{
    public class ShouldBeGreaterOrEqualTo : ValidationAttribute
    {
        private readonly double number;

        public ShouldBeGreaterOrEqualTo(double number)
            : base($"This field should be greater or equal to: RD${number:N}")
        {
            this.number = number;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return value is null || Convert.ToDouble(value) >= number
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage);
        }
    }
}
