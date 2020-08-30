using System.ComponentModel;

namespace SalaryDiscountCalculatorWeb.Views.Salary
{
    public class SalaryViewModel
    {
        [DisplayName("Salario (mensual)")]
        public string MonthlySalary { set; get; }

        [DisplayName("Salario (anual)")]
        public string AnnualSalary { get; set; }

        [DisplayName("Salario menos AFP y SFS (mensual)")]
        public string MonthlySalaryAfterAfpAndSfsDiscount { get; set; }

        [DisplayName("Salario menos AFP y SFS (anual)")]
        public string AnnualSalaryAfterAfpAndSfsDiscount { get; set; }

        [DisplayName("Salario menos AFP, SFS y ISR (mensual)")]
        public string MonthlySalaryAfterTotalDiscount { get; set; }

        [DisplayName("Salario menos AFP, SFS y ISR (anual)")]
        public string AnnualSalaryAfterTotalDiscount { get; set; }

        [DisplayName("% AFP")]
        public string AfpPercent { get; set; }

        [DisplayName("Descuento AFP (mensual)")]
        public string AfpMonthlyDiscount { get; set; }

        [DisplayName("Descuento AFP (anual)")]
        public string AfpAnnualDiscount { get; set; }

        [DisplayName("% SFS")]
        public string SfsPercent { get; set; }

        [DisplayName("Descuento SFS (mensual)")]
        public string SfsMonthlyDiscount { get; set; }

        [DisplayName("Descuento SFS (anual)")]
        public string SfsAnnualDiscount { get; set; }

        [DisplayName("Categoría ISR")]
        public string IsrCategory { get; set; }

        [DisplayName("Descuento ISR (mensual)")]
        public string IsrMonthlyDiscount { get; set; }

        [DisplayName("Descuento ISR (anual)")]
        public string IsrAnnualDiscount { get; set; }

        [DisplayName("Total descuento (mensual)")]
        public string MonthlyTotalDiscount { get; set; }

        [DisplayName("Total descuento (anual)")]
        public string AnnualTotalDiscount { get; set; }
    }
}
