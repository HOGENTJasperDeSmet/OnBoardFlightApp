using Newtonsoft.Json;
using OnBoardFlightApp.Model;
using OnBoardFlightApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.ViewModel
{
    class HomeViewModel
    {
        public Zetel Zetel { get; set; }
        public Flight Flight { get; set; }

        public HomeViewModel()
        {
            FlightService flightService = FlightService.Instance;
            Flight = flightService.Flight;
            App app = (App)App.Current;
            app.GetZetel(app.Zetel.Id);
            var zetel = app.Zetel;
            Zetel = zetel;
        }
    }
}
