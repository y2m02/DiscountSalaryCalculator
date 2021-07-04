using Microsoft.AspNetCore.Mvc;
using SalaryDiscountCalculatorWeb.Models.Salary;

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

            var salary = new Salary((decimal)request.Salary!).CalculateDiscount();

            return View(
                "ShowDiscounts",
                new SalaryViewModel
                {
                    MonthlySalary = salary.MonthlySalary.ToString("N"),
                    AnnualSalary = salary.AnnualSalary.ToString("N"),
                    MonthlySalaryAfterAfpAndSfsDiscount = salary.MonthlySalaryAfterAfpAndSfsDiscount.ToString("N"),
                    AnnualSalaryAfterAfpAndSfsDiscount = salary.AnnualSalaryAfterAfpAndSfsDiscount.ToString("N"),
                    MonthlySalaryAfterTotalDiscount = salary.MonthlySalaryAfterTotalDiscount.ToString("N"),
                    AnnualSalaryAfterTotalDiscount = salary.AnnualSalaryAfterTotalDiscount.ToString("N"),
                    SfsPercent = salary.SfsPercent.ToString("N4"),
                    SfsMonthlyDiscount = salary.SfsMonthlyDiscount.ToString("N"),
                    SfsAnnualDiscount = salary.SfsAnnualDiscount.ToString("N"),
                    AfpPercent = salary.AfpPercent.ToString("N4"),
                    AfpMonthlyDiscount = salary.AfpMonthlyDiscount.ToString("N"),
                    AfpAnnualDiscount = salary.AfpAnnualDiscount.ToString("N"),
                    IsrCategory = salary.IsrCategory,
                    IsrMonthlyDiscount = salary.IsrMonthlyDiscount.ToString("N"),
                    IsrAnnualDiscount = salary.IsrAnnualDiscount.ToString("N"),
                    MonthlyTotalDiscount = salary.MonthlyTotalDiscount.ToString("N"),
                    AnnualTotalDiscount = salary.AnnualTotalDiscount.ToString("N"),
                    MonthlySalaryInGfSystem = salary.MonthlySalaryInGfSystem.ToString("N"),
                    FortnightSalaryInGfSystem = salary.FortnightSalaryInGfSystem.ToString("N"),
                    FortnightSalaryInGfSystem2 = salary.FortnightSalaryInGfSystem2.ToString("N"),
                }
            );
        }
    }
}