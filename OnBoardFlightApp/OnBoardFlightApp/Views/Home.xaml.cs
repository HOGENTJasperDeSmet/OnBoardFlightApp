using Newtonsoft.Json;
using OnBoardFlightApp.Model;
using OnBoardFlightApp.Services;
using OnBoardFlightApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlightApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();
        DateTime deptDateTime;
        DateTime arrDatetime;
        BasicGeoposition origin;
        BasicGeoposition destination;
        BasicGeoposition travelled;
        MapPolyline lineTravelled;
        MapPolyline line;
        MapIcon VliegtuigIcon;
        public Home()
        {

            this.InitializeComponent();
            map.Style = Windows.UI.Xaml.Controls.Maps.MapStyle.Aerial3DWithRoads;
            map.MapProjection = Windows.UI.Xaml.Controls.Maps.MapProjection.Globe;
            ShowRouteOnMap();
            map.MapServiceToken = "Wlmxnwrh1DbLmvNxtiYT~b7sS5Eetr3-5c06L7qVkKA~Auir0q538T9rXDlFy-nctuxhWBFfg1zd814D6GxTC-h-k28FIWjsweuQzXVVyCit";

            Timer.Tick += tickClock;
            deptDateTime = DateTime.Now.AddMinutes(-1);
            arrDatetime = DateTime.Now.AddMinutes(2);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

        }

        private void tickClock(object sender, object e)
        {
            var total = (ViewModel.Flight.ArrivalTime - ViewModel.Flight.DepartureTime).TotalSeconds;
            var percentage = (DateTime.Now - ViewModel.Flight.DepartureTime).TotalSeconds * 100 / total;
            progress.Value = percentage;
            if (percentage < 100)
            {
                calculatePointBasedOnPercentage(percentage /100);
            }
            currentTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void calculatePointBasedOnPercentage(double per)
        {
                travelled.Latitude = origin.Latitude + (destination.Latitude - origin.Latitude) * per;
                travelled.Longitude = origin.Longitude + (destination.Longitude - origin.Longitude) * per;
                lineTravelled.Path = new Geopath(new List<BasicGeoposition> { origin, travelled });
                line.Path = new Geopath(new List<BasicGeoposition> { travelled, destination });
        }
        private async void ShowRouteOnMap()
        {
            origin = new BasicGeoposition() { Latitude = ViewModel.Flight.Origine.Lattitude, Longitude = ViewModel.Flight.Origine.Longitude };
            destination = new BasicGeoposition() { Latitude = ViewModel.Flight.Bestemming.Lattitude, Longitude = ViewModel.Flight.Bestemming.Longitude };
            BasicGeoposition middle = new BasicGeoposition() { Latitude = (origin.Latitude + destination.Latitude) / 2, Longitude = (origin.Longitude + destination.Longitude) / 2 };
            Geopoint middleGeopoint = new Geopoint(middle);


            lineTravelled = new MapPolyline();
            line = new MapPolyline();

            calculatePointBasedOnPercentage(0.20);
            lineTravelled.Path = new Geopath(new List<BasicGeoposition> { origin, travelled });
            lineTravelled.StrokeColor = Colors.Turquoise;
            lineTravelled.StrokeThickness = 6;
            map.MapElements.Add(lineTravelled);


            line.Path = new Geopath(new List<BasicGeoposition> { travelled, destination });
            line.StrokeColor = Colors.White;
            line.StrokeThickness = 5;
            line.StrokeDashed = true;
            map.MapElements.Add(line);

            await map.TrySetViewAsync(middleGeopoint, 4.8, 0, 30, MapAnimationKind.Bow);

        }
    }
}
