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
        private const string ApiKey = "36c42db20b8dcd535b5b0f21fd188416d332d164f907bbfbe5e75009bf4a9eb7";

        public CoinCapService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
        }

        public async Task<List<Cryptocurrency>> GetCurrenciesAsync()
        {
            var response = await httpClient.GetAsync($"https://rest.coincap.io/v3/assets?limit=2500");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            var data = json["data"];
            var result = data.ToObject<List<Cryptocurrency>>();
            return result ?? new List<Cryptocurrency>();
        }

        public async Task<List<Market>> GetMarketsForCurrencyAsync(string currencyId)
        {
            var response = await httpClient.GetAsync($"https://rest.coincap.io/v3/markets?baseId={currencyId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MarketResponse>(content);

            return result?.Data ?? new List<Market>();
        }
    }
}
