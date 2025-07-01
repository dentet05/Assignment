using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class MarketResponse
    {
        [JsonProperty("data")]
        public List<Market> Data { get; set; }
    }
}
