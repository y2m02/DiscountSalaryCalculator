using System;

namespace DiscountCalculator
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string breaker;
            do
            {
                CalculateDiscounts();

                Console.Write("¿Desea calcular otra cantidad? (S / s = \"Sí\"; N / n = \"No\") => ");
                breaker = Console.ReadLine();

            } while (breaker.ToLower() != "n");

            Console.WriteLine();
            Console.Write("¡Sé feliz!");
            Console.ReadKey();
        }

        private static void CalculateDiscounts()
        {
            Console.Clear();
            Console.WriteLine("CALCULADORA DE DESCUENTOS");
            Console.WriteLine();
            Console.Write("Escriba su salario: ");
            var amount = decimal.Parse(Console.ReadLine());

            var salary = new SalaryModel(amount).CalculateDiscount();

            Console.Clear();
            Console.WriteLine("CALCULADORA DE DESCUENTOS");
            Console.WriteLine();
            Console.WriteLine($"Salario mensual: RD${salary.MonthlySalary:N}");
            Console.WriteLine($"Salario anual: RD${salary.AnnualSalary:N}");
            Console.WriteLine();
            Console.WriteLine($"% AFP mensual: {salary.AfpPercent * 100:N}");
            Console.WriteLine($"Descuento AFP mensual: RD${salary.AfpMonthlyDiscount:N}");
            Console.WriteLine($"Descuento AFP anual: RD${salary.AfpAnnualDiscount:N}");
            Console.WriteLine();
            Console.WriteLine($"% SFS mensual: {salary.SfsPercent * 100:N}");
            Console.WriteLine($"Descuento SFS mensual: RD${salary.SfsMonthlyDiscount:N}");
            Console.WriteLine($"Descuento SFS anual: RD${salary.SfsAnnualDiscount:N}");
            Console.WriteLine();
            Console.WriteLine($"Salario mensual con descuentos AFP y SFS: RD${salary.MonthlySalaryAfterAfpAndSfsDiscount:N}");
            Console.WriteLine($"Salario anual con descuentos AFP y SFS: RD${salary.AnnualSalaryAfterAfpAndSfsDiscount:N}");
            Console.WriteLine();
            Console.WriteLine("Categoría ISR:");
            Console.WriteLine($"{salary.IsrCategory}");
            Console.WriteLine($"Descuento ISR mensual: RD${salary.IsrMonthlyDiscount:N}");
            Console.WriteLine($"Descuento ISR anual: RD${salary.IsrAnnualDiscount:N}");
            Console.WriteLine();
            Console.WriteLine($"Total descuento mensual: RD${salary.MonthlyTotalDiscount:N}");
            Console.WriteLine($"Total descuento anual: RD${salary.AnnualTotalDiscount:N}");
            Console.WriteLine();
            Console.WriteLine($"Salario con descuento mensual: RD${salary.MonthlySalaryAfterDiscount:N}");
            Console.WriteLine($"Salario con descuento anual: RD${salary.AnnualSalaryAfterDiscount:N}");
            Console.WriteLine();
        }
    }
}