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
        public SplashPage SplashPage = new SplashPage();
        public Flight Flight;

        public SplashScreenViewModel()
        {
            FlightService flightService = FlightService.Instance;
            Flight = flightService.Flight;
            Flight.PropertyChanged += Flight_PropertyChanged;
        }

        private void Flight_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SplashPage.getSplashArt(Flight.Bestemming.Naam);
        }
    }
}
