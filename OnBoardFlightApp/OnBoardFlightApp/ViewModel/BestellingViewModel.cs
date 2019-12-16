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
    class BestellingViewModel
    {
        public ObservableCollection<Bestelling> Bestellingen { get; set; }
        public HttpClient client;

        public BestellingViewModel()
        {
            client = new HttpClient();
            Bestellingen = new ObservableCollection<Bestelling>();
            GetAll();
        }

        public async void GetAll()
        {
            App app = (App)App.Current;
            app.GetZetel(app.Zetel.Id);
            if (!app.IsLegeZetel())
            {
                var id = app.Zetel.Passagier.Id;
                var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Bestelling/user/" + id));
                var list = JsonConvert.DeserializeObject<IEnumerable<Bestelling>>(json);
                foreach (var i in list)
                {
                    Bestellingen.Add(i);
                }
            }
        }
    }
}
