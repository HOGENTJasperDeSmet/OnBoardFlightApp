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
    class MeldingViewModel
    {
        public ObservableCollection<Melding> Meldingen { get; set; }
        public HttpClient Client;

        public MeldingViewModel()
        {
            Client = new HttpClient();
            Meldingen = new ObservableCollection<Melding>();
            GetAll();
        }

        public async void GetAll()
        {
            App app = (App)App.Current;
            app.GetZetel(app.Zetel.Id);
            if (!app.IsLegeZetel())
            {
                var id = app.Zetel.Passagier.Id;
                var json = await Client.GetStringAsync(new Uri("http://localhost:5000/api/Passagier/melding/" + id));
                var list = JsonConvert.DeserializeObject<IEnumerable<Melding>>(json);
                foreach (var i in list)
                {
                    Meldingen.Add(i);
                }
            }
        }
    }
}
