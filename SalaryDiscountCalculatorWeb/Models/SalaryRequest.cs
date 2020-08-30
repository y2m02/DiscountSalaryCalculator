using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalaryDiscountCalculatorWeb.Models
{
    public class SalaryRequest
    {
        [Required(ErrorMessage = "Campo requerido")]
        [Range(10000, double.MaxValue, ErrorMessage = "El salario mínimo aceptado es RD${1:N}")]
        [DisplayName("Salario mensual")]
        public decimal? Salary { get; set; }
    }
}