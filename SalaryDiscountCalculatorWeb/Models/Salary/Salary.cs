using System.ComponentModel;

namespace SalaryDiscountCalculatorWeb.Models.Salary
{
    public class Salary
    {
        public Salary(decimal salary)
        {
            MonthlySalary = salary;
        }

        [DisplayName("Salario (mensual)")]
        public decimal MonthlySalary { get; }

        public decimal AnnualSalary => MonthlySalary * 12;

        public decimal MonthlySalaryAfterAfpAndSfsDiscount => MonthlySalary - AfpMonthlyDiscount - SfsMonthlyDiscount;
        public decimal AnnualSalaryAfterAfpAndSfsDiscount => MonthlySalaryAfterAfpAndSfsDiscount * 12;

        public decimal MonthlySalaryAfterTotalDiscount { get; set; }
        public decimal AnnualSalaryAfterTotalDiscount { get; set; }

        public decimal SfsPercent => 0.0304m;
        public decimal SfsMonthlyDiscount => MonthlySalary * SfsPercent;
        public decimal SfsAnnualDiscount => SfsMonthlyDiscount * 12;

        public decimal AfpPercent => 0.0287m;
        public decimal AfpMonthlyDiscount => MonthlySalary * AfpPercent;
        public decimal AfpAnnualDiscount => AfpMonthlyDiscount * 12;

        public string IsrCategory { get; set; }
        public decimal IsrMonthlyDiscount { get; set; }
        public decimal IsrAnnualDiscount { get; set; }

        public decimal MonthlyTotalDiscount { get; set; }
        public decimal AnnualTotalDiscount { get; set; }

        public decimal MonthlySalaryInGfSystem { get; set; }
        public decimal FortnightSalaryInGfSystem { get; set; }
        public decimal FortnightSalaryInGfSystem2 { get; set; }

        public Salary CalculateDiscount()
        {
            CalculateIsr();
            SetTotalDiscount();
            SetAmountAfterDiscount();

            return this;
        }

        private void CalculateIsr()
        {
            const decimal firstCategoryUpperLimitQty = 416220.00m;

            if (AnnualSalaryAfterAfpAndSfsDiscount <= firstCategoryUpperLimitQty)
            {
                IsrCategory = $"1. ​Rentas hasta RD${firstCategoryUpperLimitQty:N}: " +
                    "Exento";

                IsrAnnualDiscount = 0;

                return;
            }

            const decimal secondCategoryLowerLimitQty = 416220.01m;
            const decimal secondCategoryUpperLimitQty = 624329.00m;
            decimal percent;

            if (AnnualSalaryAfterAfpAndSfsDiscount >= secondCategoryLowerLimitQty &&
                AnnualSalaryAfterAfpAndSfsDiscount <= secondCategoryUpperLimitQty)
            {
                percent = 0.15m;

                IsrCategory =
                    $"2. ​​Rentas desde RD${secondCategoryLowerLimitQty:N} hasta RD${secondCategoryUpperLimitQty:N}: " +
                    $"{percent * 100:N0}% del excedente de RD${secondCategoryLowerLimitQty:N}";

                IsrAnnualDiscount = CalculateIsrDiscount(secondCategoryLowerLimitQty, percent);
                IsrMonthlyDiscount = IsrAnnualDiscount / 12;

                return;
            }

            const decimal thirdCategoryLowerLimitQty = 624329.01m;
            const decimal thirdCategoryUpperLimitQty = 867123.00m;
            decimal additionalAmount;

            if (AnnualSalaryAfterAfpAndSfsDiscount >= thirdCategoryLowerLimitQty &&
                AnnualSalaryAfterAfpAndSfsDiscount <= thirdCategoryUpperLimitQty)
            {
                additionalAmount = 31216.00m;
                percent = 0.20m;

                IsrCategory =
                    $"3. ​Rentas desde RD${thirdCategoryLowerLimitQty:N} hasta RD${thirdCategoryUpperLimitQty:N}: " +
                    $"RD${additionalAmount:N} más el {percent * 100:N0}% del excedente de RD${thirdCategoryLowerLimitQty:N}";

                IsrAnnualDiscount = CalculateIsrDiscount(thirdCategoryLowerLimitQty, percent, additionalAmount);
                IsrMonthlyDiscount = IsrAnnualDiscount / 12;

                return;
            }

            const decimal fourthCategoryLowerLimitQty = 867123.01m;

            if (AnnualSalaryAfterAfpAndSfsDiscount >= fourthCategoryLowerLimitQty)
            {
                additionalAmount = 79776.00m;
                percent = 0.25m;

                IsrCategory = $"4. Rentas desde  RD${fourthCategoryLowerLimitQty:N} en adelante: " +
                    $"RD${additionalAmount:N} más el {percent * 100:N0}% del excedente de RD${fourthCategoryLowerLimitQty:N}";

                IsrAnnualDiscount = CalculateIsrDiscount(fourthCategoryLowerLimitQty, percent, additionalAmount);
                IsrMonthlyDiscount = IsrAnnualDiscount / 12;
            }
        }

        private void SetTotalDiscount()
        {
            AnnualTotalDiscount = AfpAnnualDiscount + SfsAnnualDiscount + IsrAnnualDiscount;
            MonthlyTotalDiscount = AnnualTotalDiscount / 12;
        }

        private void SetAmountAfterDiscount()
        {
            AnnualSalaryAfterTotalDiscount = AnnualSalary - AnnualTotalDiscount;
            MonthlySalaryAfterTotalDiscount = MonthlySalary - MonthlyTotalDiscount;

            // Reference salary: 93,000
            FortnightSalaryInGfSystem = MonthlySalaryAfterTotalDiscount * 36759.30m / 77044.84m;
            FortnightSalaryInGfSystem2 = MonthlySalaryAfterTotalDiscount * 34856.46m / 77044.84m;
            MonthlySalaryInGfSystem = FortnightSalaryInGfSystem * 2;
        }

        private decimal CalculateIsrDiscount(decimal lowerLimit, decimal percent, decimal amount = 0)
        {
            return (AnnualSalaryAfterAfpAndSfsDiscount - lowerLimit) * percent + amount;
        }
    }
}