using Newtonsoft.Json;
using OnBoardFlightApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.ViewModel
{
    class PersoneelBestellingViewModel
    {
        public ObservableCollection<BestellingObjectVoorPersoneel> AlleBestellingen { get; set; }
        private string _token = "";
        public string Token { get { return _token; } set {
                _token = value;
                GetAll();
            } }
        public HttpClient client;

        public PersoneelBestellingViewModel()
        {
            client = new HttpClient();
            AlleBestellingen = new ObservableCollection<BestellingObjectVoorPersoneel>();
        }

        public async void GetAll()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Bestelling"));
            var list = JsonConvert.DeserializeObject<IEnumerable<BestellingObjectVoorPersoneel>>(json);
            foreach(var i in list)
            {
                i.Token = Token;
                AlleBestellingen.Add(i);
            }
        }
    }
}
