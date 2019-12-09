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
            Zetel = new Zetel();
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
