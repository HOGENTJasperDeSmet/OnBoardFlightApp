using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class Mp3ViewModel
    {
        public ObservableCollection<MP3> Songs { get; set; }

        public Mp3ViewModel()
        {
            Songs = new ObservableCollection<MP3>();
            loadDataAsync();
        }
        private async void loadDataAsync()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("https://openwhyd.org/adrien?format=json"));
            List<MP3> items = JsonConvert.DeserializeObject<List<MP3>>(json);
           
            foreach (var item in items)
            {
                var i = (string)item.ToString();
                var itemGoed = i.Substring(1, i.Length - 2);
                Songs.Add(item);
            }
        }
    }
}
