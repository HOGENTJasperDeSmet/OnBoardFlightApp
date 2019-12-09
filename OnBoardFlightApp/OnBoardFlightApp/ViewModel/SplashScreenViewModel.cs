using OnBoardFlightApp.Model;
using OnBoardFlightApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.ViewModel
{
    class SplashScreenViewModel
    {
        public WeatherService weatherService;
        public SplashPage SplashPage = new SplashPage();
        public Flight Flight { get; set; }
        public Model.Weather WeatherBestemming { get; set;  }
        public Model.Weather WeatherOrigin { get; set; }
        public SplashScreenViewModel()
        {
            weatherService = WeatherService.Instance;
            FlightService flightService = FlightService.Instance;
            Flight = flightService.Flight;
            WeatherBestemming = weatherService.WeatherBestemming;
            WeatherOrigin = weatherService.WeatherOrigin;
            Flight.PropertyChanged += Flight_PropertyChanged;
        }

        private void Flight_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SplashPage.getSplashArt(Flight.Bestemming.Naam);
            if(e.PropertyName == "Bestemming")
                weatherService.getWeather(Flight.Bestemming.Naam,WeatherBestemming);
            if(e.PropertyName == "Origine")
                weatherService.getWeather(Flight.Origine.Naam, WeatherOrigin);
        }
    }
}
