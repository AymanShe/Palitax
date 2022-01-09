using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ITaxJarService
    {
        Task<float> GetTotalTax(string country, string state, string zipCode, float amount);
    }
    public class TaxJarService : ITaxJarService
    {
        private HttpClient _httpClient;

        public TaxJarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<float> GetTotalTax(string country, string state, string zipCode, float amount)
        {
            var requestModel = new TaxJarRequestModel
            {
                amount = amount,
                from_country = country,
                to_country = country,
                from_state = state,
                to_state = state,
                from_zip = zipCode,
                to_zip = zipCode
            };

            var jsonString = JsonSerializer.Serialize(requestModel);
            var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //TODO try catch
            var response = await _httpClient.PostAsync("", data);
            TaxJarResponseModel taxJarResponseModel = null;
            if (response.IsSuccessStatusCode)
            {
                taxJarResponseModel = await response.Content.ReadFromJsonAsync<TaxJarResponseModel>();
            }

            return taxJarResponseModel.tax.amount_to_collect;
        }
    }
}
