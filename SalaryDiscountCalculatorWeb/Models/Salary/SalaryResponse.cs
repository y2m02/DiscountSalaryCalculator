using Newtonsoft.Json;

namespace SalaryDiscountCalculatorWeb.Models.Salary
{
    public class SalaryResponse
    {
        [JsonProperty("salaryPerYear")]
        public decimal SalaryPerYear { get; set; }

        [JsonProperty("salaryPerMonth")]
        public decimal SalaryPerMonth { get; set; }

        [JsonProperty("salaryPerYearAfterAfpAndSfsDiscounts")]
        public decimal SalaryPerYearAfterAfpAndSfsDiscounts { get; set; }

        [JsonProperty("salaryPerMonthAfterAfpAndSfsDiscounts")]
        public decimal SalaryPerMonthAfterAfpAndSfsDiscounts { get; set; }

        [JsonProperty("netSalaryPerYear")]
        public decimal NetSalaryPerYear { get; set; }

        [JsonProperty("netSalaryPerMonth")]
        public decimal NetSalaryPerMonth { get; set; }

        [JsonProperty("sfsPercent")]
        public decimal SfsPercent { get; set; }

        [JsonProperty("sfsDiscountPerYear")]
        public decimal SfsDiscountPerYear { get; set; }

        [JsonProperty("sfsDiscountPerMonth")]
        public decimal SfsDiscountPerMonth { get; set; }

        [JsonProperty("afpPercent")]
        public decimal AfpPercent { get; set; }

        [JsonProperty("afpDiscountPerYear")]
        public decimal AfpDiscountPerYear { get; set; }

        [JsonProperty("afpDiscountPerMonth")]
        public decimal AfpDiscountPerMonth { get; set; }

        [JsonProperty("isrCategory")]
        public string IsrCategory { get; set; }

        [JsonProperty("isrDiscountPerYear")]
        public decimal IsrDiscountPerYear { get; set; }

        [JsonProperty("isrDiscountPerMonth")]
        public decimal IsrDiscountPerMonth { get; set; }

        [JsonProperty("totalDiscountPerYear")]
        public decimal TotalDiscountPerYear { get; set; }

        [JsonProperty("totalDiscountPerMonth")]
        public decimal TotalDiscountPerMonth { get; set; }

        [JsonProperty("salaryPerMonthInGfSystem")]
        public decimal SalaryPerMonthInGfSystem { get; set; }

        [JsonProperty("salaryPerYearInGfSystem")]
        public decimal SalaryPerYearInGfSystem { get; set; }

        [JsonProperty("fortnightSalaryInGfSystem")]
        public decimal FortnightSalaryInGfSystem { get; set; }

        [JsonProperty("fortnightSalaryInGfSystem2")]
        public decimal FortnightSalaryInGfSystem2 { get; set; }
    }
}
