using Newtonsoft.Json;
using OnBoardFlightApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.ViewModel
{
   public class MovieViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; }

        public MovieViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            loadDataAsync();
        }

        private async void loadDataAsync()
        {
            HttpClient client = new HttpClient();
           var json = await client.GetStringAsync(new Uri("http://www.omdbapi.com/?i=tt1156398&apikey=b51adcd9"));
            var movie2 = JsonConvert.DeserializeObject<Movie>(json);
            movie2.SourceMP4 = "ms-appx:///Assets/DummyMP4/zombieland.mp4";
            Movies.Add(movie2);
            json = await client.GetStringAsync(new Uri("http://www.omdbapi.com/?i=tt1119646&apikey=b51adcd9"));
            var movie3 = JsonConvert.DeserializeObject<Movie>(json);
            movie3.SourceMP4 = "ms-appx:///Assets/DummyMP4/hangover.mp4";
            Movies.Add(movie3);
            json = await client.GetStringAsync(new Uri("http://www.omdbapi.com/?i=tt1285016&apikey=b51adcd9"));
            var movie4 = JsonConvert.DeserializeObject<Movie>(json);
            movie4.SourceMP4 = "ms-appx:///Assets/DummyMP4/thesocialnetwork.mp4";
            Movies.Add(movie4);
            json = await client.GetStringAsync(new Uri("http://www.omdbapi.com/?i=tt0083658&apikey=b51adcd9"));
            var movie5 = JsonConvert.DeserializeObject<Movie>(json);
            movie5.SourceMP4 = "ms-appx:///Assets/DummyMP4/hangover.mp4";
            Movies.Add(movie5);
            json = await client.GetStringAsync(new Uri("http://www.omdbapi.com/?i=tt0109830&apikey=b51adcd9"));
            var movie6 = JsonConvert.DeserializeObject<Movie>(json);
            movie6.SourceMP4 = "ms-appx:///Assets/DummyMP4/hangover.mp4";
            Movies.Add(movie6);
            json = await client.GetStringAsync(new Uri("http://www.omdbapi.com/?i=tt0077869&apikey=b51adcd9"));
            var movie7 = JsonConvert.DeserializeObject<Movie>(json);
            movie7.SourceMP4 = "ms-appx:///Assets/DummyMP4/hangover.mp4";
            Movies.Add(movie7);
            json = await client.GetStringAsync(new Uri("http://www.omdbapi.com/?i=tt0120815&apikey=b51adcd9"));
            var movie8 = JsonConvert.DeserializeObject<Movie>(json);
            movie8.SourceMP4 = "ms-appx:///Assets/DummyMP4/hangover.mp4";
            Movies.Add(movie8);
            json = await client.GetStringAsync(new Uri("http://www.omdbapi.com/?i=tt0073195&apikey=b51adcd9"));
            var movie9 = JsonConvert.DeserializeObject<Movie>(json);
            movie9.SourceMP4 = "ms-appx:///Assets/DummyMP4/hangover.mp4";
            Movies.Add(movie9);
            json = await client.GetStringAsync(new Uri("http://www.omdbapi.com/?i=tt0091763&apikey=b51adcd9"));
            var movie10 = JsonConvert.DeserializeObject<Movie>(json);
            movie10.SourceMP4 = "ms-appx:///Assets/DummyMP4/hangover.mp4";
            Movies.Add(movie10);
        }
    }
}
