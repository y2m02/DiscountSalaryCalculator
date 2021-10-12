using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalaryDiscountCalculatorWeb.Models.Salary;
using SalaryDiscountCalculatorWeb.Services;

namespace SalaryDiscountCalculatorWeb.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IApiClient client;
        private readonly IMapper mapper;

        public SalaryController(IApiClient client, IMapper mapper)
        {
            this.client = client;
            this.mapper = mapper;
        }

        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(SalaryRequest request)
        {
            if (!ModelState.IsValid) return View();

            var response = await client
                .Get<SalaryResponse>($"discountcalculator/calculate?salary={request.Salary}&paymentType={request.PaymentType}")
                .ConfigureAwait(false);

            return View("ShowDiscounts", mapper.Map<SalaryViewModel>(response));
        }
    }
}
