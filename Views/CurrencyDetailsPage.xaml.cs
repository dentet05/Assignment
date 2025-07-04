using Assignment.Models;
using Assignment.ViewModels;
using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CurrencyDetailsPage : Page
    {
        public CurrencyDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var currency = e.Parameter as Cryptocurrency;
            var vm = new CurrencyDetailsViewModel { Currency = currency };
            this.DataContext = vm;
            await vm.LoadMarketsAsync(currency.Id);
        }

        private async void OnMarketButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string url)
            {
                var uri = new Uri(url);
                await Windows.System.Launcher.LaunchUriAsync(uri);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
    }
}
