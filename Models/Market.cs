using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Market
    {
        [JsonProperty("exchangeId")]
        public string ExchangeId { get; set; }

        [JsonProperty("baseSymbol")]
        public string BaseSymbol { get; set; }

        [JsonProperty("quoteSymbol")]
        public string QuoteSymbol { get; set; }

        [JsonProperty("priceUsd")]
        public string PriceUsd { get; set; }
        public string MarketUrl => $"https://coincap.io/exchanges/{ExchangeId}";

        public string PriceUsdFormatted
        {
            get
            {
                if (double.TryParse(PriceUsd, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                    return $"${result:F2}";
                return PriceUsd;
            }
        }
    }
}
