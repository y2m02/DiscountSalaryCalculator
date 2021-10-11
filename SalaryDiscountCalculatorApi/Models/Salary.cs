namespace SalaryDiscountCalculatorApi.Models
{
    public class Salary
    {
        public decimal SalaryPerYear { get; init; }
        public decimal SalaryPerMonth => SalaryPerYear / 12;

        public decimal SalaryPerYearAfterAfpAndSfsDiscounts => SalaryPerMonthAfterAfpAndSfsDiscounts * 12;

        public decimal SalaryPerMonthAfterAfpAndSfsDiscounts => SalaryPerMonth - AfpDiscountPerMonth - SfsDiscountPerMonth;

        public decimal NetSalaryPerYear { get; init; }
        public decimal NetSalaryPerMonth => NetSalaryPerYear / 12;

        public decimal SfsPercent { get; init; }
        public decimal SfsDiscountPerYear { get; init; }
        public decimal SfsDiscountPerMonth => SfsDiscountPerYear / 12;

        public decimal AfpPercent { get; init; }
        public decimal AfpDiscountPerYear { get; init; }
        public decimal AfpDiscountPerMonth => AfpDiscountPerYear / 12;

        public string IsrCategory { get; init; }
        public decimal IsrDiscountPerYear { get; init; }
        public decimal IsrDiscountPerMonth => IsrDiscountPerYear / 12;

        public decimal TotalDiscountPerYear => SfsDiscountPerYear + AfpDiscountPerYear + IsrDiscountPerYear;
        public decimal TotalDiscountPerMonth => TotalDiscountPerYear / 12;

        // Reference salary: 93,000
        public decimal SalaryPerMonthInGfSystem => FortnightSalaryInGfSystem * 2;
        public decimal SalaryPerYearInGfSystem => SalaryPerMonthInGfSystem * 12;
        public decimal FortnightSalaryInGfSystem => NetSalaryPerMonth * 36759.30m / 77044.84m;
        public decimal FortnightSalaryInGfSystem2 => NetSalaryPerMonth * 34856.46m / 77044.84m;
    }
}
