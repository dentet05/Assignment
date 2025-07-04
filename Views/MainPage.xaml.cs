using Assignment.Models;
using Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Assignment.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a <see cref="Frame">.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel Vm => (MainViewModel)DataContext;
        private ObservableCollection<Cryptocurrency> allCurrencies = new ObservableCollection<Cryptocurrency>();

        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await Vm.LoadCurrenciesAsync();
            allCurrencies = new ObservableCollection<Cryptocurrency>(Vm.Currencies);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selected = e.ClickedItem as Cryptocurrency;
            if (selected != null)
            {
                Frame.Navigate(typeof(CurrencyDetailsPage), selected);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = (sender as TextBox)?.Text ?? "";
            Vm.FilterCurrencies(query);
        }
    }
}
