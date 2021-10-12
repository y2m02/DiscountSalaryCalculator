using System.ComponentModel;

namespace SalaryDiscountCalculatorWeb.Models.Salary
{
    public enum PaymentType
    {
        [Description("Mensual")]
        Monthly,

        [Description("Anual")]
        Annually,
    }
}
