using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OnBoardFlightApp.Services
{
    class WeatherService
    {
        private static WeatherService _instance = new WeatherService();
        public Model.Weather WeatherBestemming;
        public Model.Weather WeatherOrigin;
        private WeatherService()
        {
            WeatherBestemming = new Model.Weather();
            WeatherOrigin = new Model.Weather();
        }

        public static WeatherService Instance {
            get {
                return _instance;
            }
        }
        public async void getWeather(String plaats, Model.Weather weather)
        {
            RootObject myWeather = await OpenWeatherMapProxy.GetWeather(plaats);
            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
            weather.Naam = plaats;
            weather.Temperatuur = ((int)myWeather.main.temp).ToString() + "°";
            weather.Description = myWeather.weather[0].description;
            weather.Icon = new BitmapImage(new Uri(icon, UriKind.Absolute));
        }
    }
}
