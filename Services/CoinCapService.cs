using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Assignment.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Assignment.Services
{
    public class CoinCapService
    {
        private readonly HttpClient httpClient;
        private const string ApiKey = "90d3de4b60864b6f24c7cc3eff224f10257a5a7bfaddd6a87ff6d5ae3c0ab0d8";

        public CoinCapService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
        }

        public async Task<List<Cryptocurrency>> GetTopCurrenciesAsync(int count = 10)
        {
            var response = await httpClient.GetAsync($"https://rest.coincap.io/v3/assets?limit={count}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            var data = json["data"];
            var result = data.ToObject<List<Cryptocurrency>>();
            return result ?? new List<Cryptocurrency>();
        }

        public async Task<List<Market>> GetMarketsForCurrencyAsync(string currencyId)
        {
            var response = await httpClient.GetAsync($"https://rest.coincap.io/v3/exchanges");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MarketResponse>(content);

            return result?.Data ?? new List<Market>();
        }
    }
}
