using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SalaryDiscountCalculatorApi.Helpers;
using SalaryDiscountCalculatorApi.Models;
using SalaryDiscountCalculatorApi.Services;

namespace SalaryDiscountCalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCalculatorController : ControllerBase
    {
        private readonly IDiscountCalculator discountCalculator;

        public DiscountCalculatorController(IDiscountCalculator discountCalculator)
        {
            this.discountCalculator = discountCalculator;
        }

        /// <summary>
        ///     Calculates the withholdings made to a specified salary in D.R.
        /// </summary>
        /// <param name="salary">
        ///     The salary whose withholdings will be calculated.
        ///     Must be greater or equal to RD$10,000.00
        /// </param>
        /// <param name="paymentType">
        ///     Whether the salary specified is per month (1) or per year (2).
        /// </param>
        /// <returns>
        ///     A model specifying all the deductions made to the specified salary.
        /// </returns>
        [HttpGet("calculate")]
        public IActionResult Calculate(
            [Required] [ShouldBeGreaterOrEqualTo(10000)]
            decimal salary,
            [Required] PaymentType paymentType
        )
        {
            var totalDiscount = discountCalculator.Calculate(
                paymentType == PaymentType.Monthly ? salary * 12 : salary
            );

            return Ok(totalDiscount);
        }
    }
}
