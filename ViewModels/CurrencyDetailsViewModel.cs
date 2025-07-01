using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Models;
using Assignment.Services;

namespace Assignment.ViewModels
{
    internal class CurrencyDetailsViewModel
    {
        public Cryptocurrency Currency { get; set; }
        public ObservableCollection<Market> Markets { get; set; } = new ObservableCollection<Market>();

        private CoinCapService service = new CoinCapService();

        public async Task LoadMarketsAsync(string currencyId)
        {
            var markets = await service.GetMarketsForCurrencyAsync(currencyId);
            Markets.Clear();
            foreach (var market in markets)
                Markets.Add(market);
        }
    }
}
