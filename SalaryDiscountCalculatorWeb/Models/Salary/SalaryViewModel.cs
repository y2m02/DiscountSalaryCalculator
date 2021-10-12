using System.ComponentModel;

namespace SalaryDiscountCalculatorWeb.Models.Salary
{
    public class SalaryViewModel
    {
        [DisplayName("Salario bruto (mensual)")]
        public string SalaryPerMonth { set; get; }

        [DisplayName("Salario bruto (anual)")]
        public string SalaryPerYear { get; set; }

        [DisplayName("% AFP")]
        public string AfpPercent { get; set; }

        [DisplayName("Descuento AFP (mensual)")]
        public string AfpDiscountPerMonth { get; set; }

        [DisplayName("Descuento AFP (anual)")]
        public string AfpDiscountPerYear { get; set; }

        [DisplayName("% SFS")]
        public string SfsPercent { get; set; }

        [DisplayName("Descuento SFS (mensual)")]
        public string SfsDiscountPerMonth { get; set; }

        [DisplayName("Descuento SFS (anual)")]
        public string SfsDiscountPerYear { get; set; }

        [DisplayName("Categoría ISR")]
        public string IsrCategory { get; set; }

        [DisplayName("Descuento ISR (mensual)")]
        public string IsrDiscountPerMonth { get; set; }

        [DisplayName("Descuento ISR (anual)")]
        public string IsrDiscountPerYear { get; set; }

        [DisplayName("Total descuento (mensual)")]
        public string TotalDiscountPerMonth { get; set; }

        [DisplayName("Total descuento (anual)")]
        public string TotalDiscountPerYear { get; set; }

        [DisplayName("Salario menos AFP y SFS (mensual)")]
        public string SalaryPerMonthAfterAfpAndSfsDiscounts { get; set; }

        [DisplayName("Salario menos AFP y SFS (anual)")]
        public string SalaryPerYearAfterAfpAndSfsDiscounts { get; set; }

        [DisplayName("Salario neto (mensual)")]
        public string NetSalaryPerMonth { get; set; }

        [DisplayName("Salario neto (anual)")]
        public string NetSalaryPerYear { get; set; }
        
        [DisplayName("Salario neto mensual (Goflow)")]
        public string SalaryPerMonthInGfSystem { get; set; }
        
        [DisplayName("Salario neto quincenal (Goflow)")]
        public string FortnightSalaryInGfSystem { get; set; }

        [DisplayName("Salario neto quincenal 2 (Goflow)")]
        public string FortnightSalaryInGfSystem2 { get; set; }
    }
}
