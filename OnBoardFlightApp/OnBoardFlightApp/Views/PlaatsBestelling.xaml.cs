using Newtonsoft.Json;
using OnBoardFlightApp.Model;
using OnBoardFlightApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace OnBoardFlightApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlaatsBestelling : Page
    {

        public PlaatsBestelling()
        {
            this.InitializeComponent();
            GetOpties();
        }

        private async void GetOpties()
        {
            var opties = await ViewModel.GetOpties();
            comboBoxOpties.ItemsSource = opties;
        }

        private async void BestelButton_Click(object sender, RoutedEventArgs e)
        {
            var i = comboBoxOpties.SelectedIndex;
            await ViewModel.Post();
            Frame.Navigate(typeof(MijnBestellingen));
        }

        private void VoegToeButton_Click(object sender, RoutedEventArgs e)
        {
            var i = comboBoxOpties.SelectedIndex;
            ViewModel.VoegOptieToe(i);
        }
    }
}
