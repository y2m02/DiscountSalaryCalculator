using Microsoft.AspNetCore.Mvc;
using SalaryDiscountCalculatorWeb.Models;

namespace SalaryDiscountCalculatorWeb.Controllers
{
    public class SalaryController : Controller
    {
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(SalaryRequest request)
        {
            if (!ModelState.IsValid) return View();

            var salary = new Salary((decimal) request.Salary).CalculateDiscount();

            return View("ShowDiscounts", salary);
        }
    }
}