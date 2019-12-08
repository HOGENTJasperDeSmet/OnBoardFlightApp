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
        public readonly string Api = "http://localhost:5000/api/Passagier/melding";
        public HttpClient Client;

        public PlaatsMeldingViewModel()
        {
            Client = new HttpClient();
        }

        public async Task<Bestelling> Post(string inhoud, int id)
        {
            var melding = new Melding { Inhoud = inhoud };
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(Api + "/" + id),
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
                    RequestUri = new Uri(Api),
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
