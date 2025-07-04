using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Assignment.Models;
using Assignment.Services;

namespace Assignment.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Cryptocurrency> Currencies { get; set; } = new ObservableCollection<Cryptocurrency>();
        private List<Cryptocurrency> allCurrencies = new List<Cryptocurrency>();
        private CoinCapService service = new CoinCapService();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public async Task LoadCurrenciesAsync()
        {
            var data = await service.GetCurrenciesAsync();
            allCurrencies = data;

            Currencies.Clear();
            foreach (var item in data.Take(10))
            {
                Currencies.Add(item);
            }
        }

        public void FilterCurrencies(string query)
        {
            var filtered = string.IsNullOrWhiteSpace(query)
                ? allCurrencies.Take(10) 
                : allCurrencies.Where(c =>
                    c.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    c.Symbol.Contains(query, StringComparison.OrdinalIgnoreCase));

            Currencies.Clear();
            foreach (var c in filtered)
                Currencies.Add(c);
        }
    }
}
