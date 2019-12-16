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
    class PlaatsMeldingViewModel
    {
        public readonly string Api = "http://localhost:5000/api/Passagier";
        public HttpClient Client;
        public List<Passagier> Passagiers { get; set; } = new List<Passagier>();

        public PlaatsMeldingViewModel()
        {
            Client = new HttpClient();
        }

        public async Task<List<string>> GetPassagiers()
        {
            var json = await Client.GetStringAsync(new Uri(Api));
            var list = JsonConvert.DeserializeObject<IEnumerable<Passagier>>(json);
            var stringLijst = new List<string>();
            foreach (var i in list)
            {
                Passagiers.Add(i);
                stringLijst.Add(i.Naam + " " + i.Voornaam);
            }
            return stringLijst;
        }

        public async Task<Bestelling> Post(string inhoud, int id)
        {
            var melding = new Melding { Inhoud = inhoud };
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(Api + "/melding/" + id),
                    Content = new StringContent(JsonConvert.SerializeObject(melding), Encoding.UTF8, "application/json")
                };
                await Client.SendAsync(request); 
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
            }

            return null;
        }

        public async Task<Bestelling> PostToAll(string inhoud)
        {
            var melding = new Melding { Inhoud = inhoud };
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(Api + "/melding"),
                    Content = new StringContent(JsonConvert.SerializeObject(melding), Encoding.UTF8, "application/json")
                };
                await Client.SendAsync(request);
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
            }

            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
