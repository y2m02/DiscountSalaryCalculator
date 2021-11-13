using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalaryDiscountCalculatorWeb.Models.Salary
{
    public class SalaryRequest
    {
        [Required(ErrorMessage = "Campo requerido")]
        [Range(10000, double.MaxValue, ErrorMessage = "El salario mínimo aceptado es RD${1:N}")]
        [DisplayName("Salario")]
        public decimal? Salary { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DisplayName("Forma de pago")]
        public PaymentType? PaymentType { get; set; }
    }
}
