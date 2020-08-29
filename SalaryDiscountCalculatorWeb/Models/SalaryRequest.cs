using System.ComponentModel;

namespace SalaryDiscountCalculatorWeb.Models
{
    public class SalaryRequest
    {
        [DisplayName("Salario mensual")]
        public decimal? Salary { get; set; }
    }
}
