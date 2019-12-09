using Newtonsoft.Json;
using OnBoardFlightApp.Model;
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
            Flight = new Flight() { Naam = "..." };
            Zetel = new Zetel();
            getFlightAsync();
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

        public void SetZetel(Zetel zetel)
        {
            Zetel.Klasse = zetel.Klasse;
            Zetel.Id = zetel.Id;
            Zetel.Rij = zetel.Rij;
            Zetel.Stoel = zetel.Stoel;
            Zetel.Passagier = zetel.Passagier;
            //Zetel.Passagier.Voornaam = zetel.Passagier.Voornaam;
        }
    }
}
