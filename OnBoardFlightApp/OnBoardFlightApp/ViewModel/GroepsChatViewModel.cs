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
        public GroepsChatViewModel()
        {
            g1 = new GroepsChat();
            GetChat();
        }

        public async void GetChat()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Groepschat/Groepschat/1"));
           GroepsChat jsongroepschat = JsonConvert.DeserializeObject<GroepsChat>(json);
            g1.Naam = jsongroepschat.Naam;
            g1.Passagiers = jsongroepschat.Passagiers;
            g1.ChatBerichten = jsongroepschat.ChatBerichten;
        }
    }
}

