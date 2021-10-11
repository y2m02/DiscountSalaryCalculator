using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("calculate")]
        public IActionResult Calculate([FromQuery] decimal salary)
        {
            var calculate = discountCalculator.Calculate(salary * 12);

            return Ok(calculate);
        }
    }
}
