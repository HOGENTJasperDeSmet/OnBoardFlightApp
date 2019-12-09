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

namespace OnBoardFlightApp.ViewModel
{
    public class GroepsChatViewModel
    {
        public GroepsChat g1 { get; set; }
        public Zetel Zetel { get; set; }
        public ObservableCollection<ChatBericht> ChatBerichten { get; set; }
        public GroepsChatViewModel()
        {
            g1 = new GroepsChat();
            ChatBerichten = new ObservableCollection<ChatBericht>();
            GetChat();
        }

        public async void GetChat()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Groepschat/Groepschat/1"));
           var chat = JsonConvert.DeserializeObject<GroepsChat>(json);
            g1 = new GroepsChat(chat.Naam, chat.Passagiers, chat.ChatBerichten);
            foreach(var i in chat.ChatBerichten)
            {
                ChatBerichten.Add(i);
            }
            var tst = g1.ChatBerichten;
        }

        internal void SetZetel(Zetel zetel)
        {
            Zetel = zetel;

        }
    }
}

