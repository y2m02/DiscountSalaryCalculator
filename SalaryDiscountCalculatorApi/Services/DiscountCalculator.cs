using HelpersLibrary.Extensions;
using Microsoft.Extensions.Configuration;
using SalaryDiscountCalculatorApi.Models;

namespace SalaryDiscountCalculatorApi.Services
{
    public interface IDiscountCalculator
    {
        Salary Calculate(decimal salaryPerYear);
    }

    public class DiscountCalculator : IDiscountCalculator
    {
        private readonly decimal afpPercent;
        private readonly IIsrCalculator isrCalculator;
        private readonly decimal sfsPercent;

        public DiscountCalculator(
            IConfiguration configuration,
            IIsrCalculator isrCalculator
        )
        {
            this.isrCalculator = isrCalculator;

            sfsPercent = configuration["Discounts:SfsPercent"].ToDecimal() / 100;
            afpPercent = configuration["Discounts:AfpPercent"].ToDecimal() / 100;
        }

        public Salary Calculate(decimal salaryPerYear)
        {
            var sfsDiscount = salaryPerYear * sfsPercent;
            var afpDiscount = salaryPerYear * afpPercent;

            var salary = salaryPerYear - sfsDiscount - afpDiscount;

            var isr = isrCalculator.Calculate(salary);

            return new()
            {
                SalaryPerYear = salaryPerYear,
                NetSalaryPerYear = salary - isr.Discount,
                SfsPercent = sfsPercent,
                SfsDiscountPerYear = sfsDiscount,
                AfpPercent = afpPercent,
                AfpDiscountPerYear = afpDiscount,
                IsrCategory = isr.Category.FormattedDescription,
                IsrDiscountPerYear = isr.Discount,
            };
        }
    }
}
