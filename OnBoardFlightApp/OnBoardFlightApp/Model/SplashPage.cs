using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OnBoardFlightApp.Model
{
    public class SplashPage : INotifyPropertyChanged
    {

    
        private BitmapImage image;
        public BitmapImage Image {
            get {
                return image;
            }
            set {
                image = value;
                RaisePropertyChanged(nameof(Image));
            }
        }

        public SplashPage()
        {
            
        }
        public async void getSplashArt(String bestemming)
        {
            HttpClient client = new HttpClient();
            Random rnd = new Random();
            var json = await client.GetStringAsync(new Uri("https://api.unsplash.com/search/photos/?client_id=f36966d3bf3670ddb2468a0585104288e040fedaa0ab7629d8dfd2b1c7306672&orientation=landscape&page=" + rnd.Next(1,8) +"&per_page=1&query=" + bestemming));
            JObject obj = JObject.Parse(json);
            Image = new BitmapImage(new Uri(obj["results"][0]["urls"]["full"].ToString()));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
