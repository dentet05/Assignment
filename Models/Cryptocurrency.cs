using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Cryptocurrency
    {
        [JsonProperty("id")]
        public string Id { get; set; } = "";

        [JsonProperty("rank")]
        public string Rank { get; set; } = "";

        [JsonProperty("symbol")]
        public string Symbol { get; set; } = "";

        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("priceUsd")]
        public string PriceUsd { get; set; } = "";

        [JsonProperty("changePercent24Hr")]
        public string ChangePercent24Hr { get; set; } = "";

        public string PriceUsdFormatted
        {
            get
            {
                if (double.TryParse(PriceUsd, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double price))
                    return price.ToString("F2");
                return PriceUsd;
            }
        }
    }
}
