namespace SalaryDiscountCalculatorApi.Models
{
    public class IsrCategory
    {
        public IsrCategories Category { get; set; }
        public string Description { get; set; }
        public decimal? UpperLimit { get; set; }
        public decimal LowerLimit { get; set; }
        public decimal PercentToDiscount { get; set; }
        public decimal AdditionalAmount { get; set; }

        public string FormattedDescription => string.Format(
            Description,
            LowerLimit,
            UpperLimit,
            AdditionalAmount,
            PercentToDiscount
        );
    }

    public enum IsrCategories
    {
        First,
        Second,
        Third,
        Fourth,
    }
}
