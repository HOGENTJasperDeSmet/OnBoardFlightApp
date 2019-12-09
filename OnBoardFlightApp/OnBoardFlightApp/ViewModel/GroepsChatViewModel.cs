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
    public class GroepsChatViewModel
    {
        public GroepsChat Groepschat { get; set; }

        public GroepsChatViewModel()
        {
            Groepschat = new GroepsChat();
            GetChat();
        }

        public async void GetChat()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Groepschat/Groepschat/1"));
            GroepsChat g1 = JsonConvert.DeserializeObject<GroepsChat>(json);
            this.Groepschat = g1;
        }
    }
}

