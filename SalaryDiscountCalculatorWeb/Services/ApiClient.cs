using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SalaryDiscountCalculatorWeb.Services
{
    public interface IApiClient
    {
        Task<T> Get<T>(string resource);
    }

    public class ApiClient : IApiClient
    {
        public async Task<T> Get<T>(string resource)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://salarydiscountcalculatorapi.azurewebsites.net/api/"),
            };

            var response = await client.GetAsync(resource).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
    }
}
