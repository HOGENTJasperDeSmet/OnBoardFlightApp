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
            
        }

        internal void SetZetel(Zetel zetel)
        {
            Zetel = zetel;

        }
    }
}

