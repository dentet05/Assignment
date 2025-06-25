using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    internal class CoinCapResponse
    {
        [JsonProperty("data")]
        public List<Cryptocurrency> Data { get; set; } = new List<Cryptocurrency>();
    }
}
