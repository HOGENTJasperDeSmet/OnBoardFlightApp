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
using Windows.UI.Xaml;

namespace OnBoardFlightApp.ViewModel
{
    public class GroepsChatViewModel
    {
        public GroepsChat g1 { get; set; }
        public Zetel Zetel { get; set; }
        public ObservableCollection<ChatBericht> ChatBerichten { get; set; }
        public readonly string Api = "http://localhost:5000/api";
        public HttpClient Client;
        public GroepsChatViewModel()
        {
            Zetel = ((App)Application.Current).Zetel;
            if(Zetel.Passagier.Groepschat != null)
            {
                GroepsChat p1 = Zetel.Passagier.Groepschat;
                ChatBerichten = p1.ChatBerichten;
            }
            else
            {
                ChatBerichten = new ObservableCollection<ChatBericht>();
            }

        }

        internal void SetZetel(Zetel zetel)
        {
            Zetel = zetel;

        }
        internal async void postChatBericht(string value)
        {
            Client = new HttpClient();
            ChatBericht chatbericht = new ChatBericht(Zetel.Passagier.Voornaam, DateTime.Now, value);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Api + "/Passagier/chatbericht/"+ Zetel.Passagier.Id),
                Content = new StringContent(JsonConvert.SerializeObject(chatbericht), Encoding.UTF8, "application/json")
               
            };
            ChatBerichten.Add(chatbericht);
            await Client.SendAsync(request);
        }
    }
}

