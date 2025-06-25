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
        private CoinCapService service = new CoinCapService();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public async Task LoadCurrenciesAsync()
        {
            var data = await service.GetTopCurrenciesAsync();

            Currencies.Clear();
            foreach (var item in data)
            {
                Currencies.Add(item);
            }
        }
    }
}
