using Newtonsoft.Json;
using OnBoardFlightApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace OnBoardFlightApp.ViewModel
{
    class PlaatsBestellingViewModel
    {
        public readonly string Api = "http://localhost:5000/api/Bestelling";
        public HttpClient Client;

        public List<BestellingOptie> BestellingOpties { get; set; } = new List<BestellingOptie>();
        public ObservableCollection<BestellingOptie> BestellingOptiesToegevoegd { get; set; } = new ObservableCollection<BestellingOptie>();

        public PlaatsBestellingViewModel()
        {
            Client = new HttpClient();
        }

        public async Task<List<string>> GetOpties()
        {
            var str = Api + "/opties";
            var json = await Client.GetStringAsync(new Uri("http://localhost:5000/api/Bestelling/opties"));
            var list = JsonConvert.DeserializeObject<IEnumerable<BestellingOptie>>(json);
            var stringLijst = new List<string>();
            foreach (var i in list)
            {
                BestellingOpties.Add(i);
                stringLijst.Add(i.Naam + " (€" + i.Prijs + ")");
            }

            return stringLijst;
        }

        public async void VoegOptieToe(int i)
        {
            if(i != -1)
            {
                BestellingOptiesToegevoegd.Add(BestellingOpties[i]);
            }
            else
            {
                await new MessageDialog("Geen optie geselecteerd").ShowAsync();
            }
        }

        public async Task<Bestelling> Post()
        {
            var bestelling = new { Afgehandeld = false, BestellingOpties = BestellingOptiesToegevoegd };
            try
            {
                App app = (App)App.Current;
                app.GetZetel(app.Zetel.Id);
                var id = app.Zetel.Passagier.Id;
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(Api + "/" + id),
                    Content = new StringContent(JsonConvert.SerializeObject(bestelling), Encoding.UTF8, "application/json")
                };
                await Client.SendAsync(request); 
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
            }

            return null;
        }
    }
}
