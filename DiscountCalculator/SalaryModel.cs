namespace DiscountCalculator
{
    public class SalaryModel
    {
        public SalaryModel(decimal salary)
        {
            MonthlySalary = salary;
        }

        public decimal MonthlySalary { get; }
        public decimal SfsPercent => 0.0304m;
        public decimal AfpPercent => 0.0287m;
        public string IsrCategory { get; private set; }
        public decimal IsrAnnualDiscount { get; private set; }
        public decimal IsrMonthlyDiscount { get; private set; }
        public decimal AnnualTotalDiscount { get; private set; }
        public decimal MonthlyTotalDiscount { get; private set; }
        public decimal AnnualSalaryAfterDiscount { get; private set; }
        public decimal MonthlySalaryAfterDiscount { get; private set; }
        public decimal AnnualSalary => MonthlySalary * 12;
        public decimal SfsMonthlyDiscount => MonthlySalary * SfsPercent;
        public decimal SfsAnnualDiscount => SfsMonthlyDiscount * 12;
        public decimal AfpMonthlyDiscount => MonthlySalary * AfpPercent;
        public decimal AfpAnnualDiscount => AfpMonthlyDiscount * 12;
        public decimal MonthlySalaryAfterAfpAndSfsDiscount => MonthlySalary - AfpMonthlyDiscount - SfsMonthlyDiscount;
        public decimal AnnualSalaryAfterAfpAndSfsDiscount => MonthlySalaryAfterAfpAndSfsDiscount * 12;

        public SalaryModel CalculateDiscount()
        {
            CalculateIsr();
            SetTotalDiscount();
            SetAmountAfterDiscount();

            return this;
        }

        private void CalculateIsr()
        {
            const decimal FirstCategoryUpperLimitQty = 416220.00m;

            if (AnnualSalaryAfterAfpAndSfsDiscount <= FirstCategoryUpperLimitQty)
            {
                IsrCategory = $"1. ​Rentas hasta RD${FirstCategoryUpperLimitQty}: " +
                              "Exento";
                IsrAnnualDiscount = 0;

                return;
            }

            const decimal SecondCategoryLowerLimitQty = 416220.01m;
            const decimal SecondCategoryUpperLimitQty = 624329.00m;
            decimal Percent;

            if (AnnualSalaryAfterAfpAndSfsDiscount >= SecondCategoryLowerLimitQty &&
                AnnualSalaryAfterAfpAndSfsDiscount <= SecondCategoryUpperLimitQty)
            {
                Percent = 0.15m;

                IsrCategory = $"2. ​​Rentas desde RD${SecondCategoryLowerLimitQty:N} hasta RD${SecondCategoryUpperLimitQty:N}: " +
                              $"{Percent * 100:N0}% del excedente de RD${SecondCategoryLowerLimitQty:N}";

                IsrAnnualDiscount = CalculateIsrDiscount(SecondCategoryLowerLimitQty, Percent);
                IsrMonthlyDiscount = IsrAnnualDiscount / 12;
                return;
            }

            const decimal ThirdCategoryLowerLimitQty = 624329.01m;
            const decimal ThirdCategoryUpperLimitQty = 867123.00m;
            decimal AdditionalAmount;

            if (AnnualSalaryAfterAfpAndSfsDiscount >= ThirdCategoryLowerLimitQty && AnnualSalaryAfterAfpAndSfsDiscount <= ThirdCategoryUpperLimitQty)
            {
                AdditionalAmount = 31216.00m;
                Percent = 0.20m;

                IsrCategory = $"3. ​Rentas desde RD${ThirdCategoryLowerLimitQty:N} hasta RD${ThirdCategoryUpperLimitQty:N}: " +
                              $"RD${AdditionalAmount:N} más el {Percent * 100:N0}% del excedente de RD${ThirdCategoryLowerLimitQty:N}";

                IsrAnnualDiscount = CalculateIsrDiscount(ThirdCategoryLowerLimitQty, Percent, AdditionalAmount);
                IsrMonthlyDiscount = IsrAnnualDiscount / 12;
                return;
            }

            const decimal FourthCategorLowerLimitQty = 867123.01m;

            if (AnnualSalaryAfterAfpAndSfsDiscount >= FourthCategorLowerLimitQty)
            {
                AdditionalAmount = 79776.00m;
                Percent = 0.25m;

                IsrCategory = $"4. Rentas desde  RD${FourthCategorLowerLimitQty:N} en adelante: " +
                              $"RD${AdditionalAmount:N} más el {Percent * 100:N0}% del excedente de RD${FourthCategorLowerLimitQty:N}";

                IsrAnnualDiscount = CalculateIsrDiscount(FourthCategorLowerLimitQty, Percent, AdditionalAmount);
                IsrMonthlyDiscount = IsrAnnualDiscount / 12;
                return;
            }
        }

        private void SetTotalDiscount()
        {
            AnnualTotalDiscount = AfpAnnualDiscount + SfsAnnualDiscount + IsrAnnualDiscount;
            MonthlyTotalDiscount = AnnualTotalDiscount / 12;
        }

        private void SetAmountAfterDiscount()
        {
            AnnualSalaryAfterDiscount = AnnualSalary - AnnualTotalDiscount;
            MonthlySalaryAfterDiscount = MonthlySalary - MonthlyTotalDiscount;

            var c = MonthlySalaryAfterDiscount * 12;
        }

        private decimal CalculateIsrDiscount(decimal lowerLimit, decimal percent, decimal amount = 0)
        {
            return ((AnnualSalaryAfterAfpAndSfsDiscount - lowerLimit) * percent) + amount;
        }
    }
}