﻿using Newtonsoft.Json;
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

namespace OnBoardFlightApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        private Flight Flight;

        public Home()
        {
            Flight = new Flight() { Naam = "..."};
            getFlightAsync();
            this.InitializeComponent();
        }

        private async void getFlightAsync()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Flight/1"));
            var lst = JsonConvert.DeserializeObject<Flight>(json);
            Flight.Bestemming = lst.Bestemming;
            Flight.DuurInUren = lst.DuurInUren;
            Flight.Origine = lst.Origine;
            Flight.Naam = lst.Naam;
        }
    }
}
