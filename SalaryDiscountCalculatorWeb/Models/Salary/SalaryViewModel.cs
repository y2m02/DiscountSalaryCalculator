﻿using System.ComponentModel;

namespace SalaryDiscountCalculatorWeb.Models.Salary
{
    public class SalaryViewModel
    {
        [DisplayName("Salario bruto (mensual)")]
        public string MonthlySalary { set; get; }

        [DisplayName("Salario bruto (anual)")]
        public string AnnualSalary { get; set; }

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

        [DisplayName("Salario menos AFP y SFS (mensual)")]
        public string MonthlySalaryAfterAfpAndSfsDiscount { get; set; }

        [DisplayName("Salario menos AFP y SFS (anual)")]
        public string AnnualSalaryAfterAfpAndSfsDiscount { get; set; }

        [DisplayName("Salario neto (mensual)")]
        public string MonthlySalaryAfterTotalDiscount { get; set; }

        [DisplayName("Salario neto (anual)")]
        public string AnnualSalaryAfterTotalDiscount { get; set; }
        
        [DisplayName("Salario neto mensual (Goflow)")]
        public string MonthlySalaryInGfSystem { get; set; }
        
        [DisplayName("Salario neto quincenal (Goflow)")]
        public string FortnightSalaryInGfSystem { get; set; }

        [DisplayName("Salario neto quincenal 2 (Goflow)")]
        public string FortnightSalaryInGfSystem2 { get; set; }
    }
}