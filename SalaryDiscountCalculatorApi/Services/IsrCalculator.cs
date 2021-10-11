using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SalaryDiscountCalculatorApi.Models;

namespace SalaryDiscountCalculatorApi.Services
{
    public interface IIsrCalculator
    {
        Isr Calculate(decimal salaryPerYear);
    }

    public class IsrCalculator : IIsrCalculator
    {
        private readonly List<IsrCategory> isrCategories = new();

        public IsrCalculator(IConfiguration configuration)
        {
            configuration.GetSection("Discounts:IsrCategories").Bind(isrCategories);
        }

        public Isr Calculate(decimal salaryPerYear)
        {
            var category = isrCategories.Single(
                c => 
                    salaryPerYear >= c.LowerLimit && 
                    salaryPerYear <= (c.UpperLimit ?? decimal.MaxValue)
            );

            return new()
            {
                Discount = (salaryPerYear - category.LowerLimit) *
                    (category.PercentToDiscount / 100) +
                    category.AdditionalAmount,
                Category = category,
            };
        }
    }
}
