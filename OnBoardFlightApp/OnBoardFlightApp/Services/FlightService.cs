using Newtonsoft.Json;
using OnBoardFlightApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Services
{
    public class FlightService
    {
        private static FlightService _instance = new FlightService();
        public Flight Flight;
        private FlightService() {
            Flight = new Flight() { Naam = "..." };
            getFlightAsync();
        }

        public static FlightService Instance {
            get {
                return _instance;
            }
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
