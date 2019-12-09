using Newtonsoft.Json;
using OnBoardFlightApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace OnBoardFlightApp.ViewModel
{
    class MainPageViewModel
    {
        public readonly string Api = "http://localhost:5000/api/Flight/zetels/";
        public HttpClient Client;
        public Zetel Zetel { get; set; }

        public MainPageViewModel()
        {
            Client = new HttpClient();
        }

        public async Task<Zetel> GetZetel(int id)
        {
            try
            {
                var json = await Client.GetStringAsync(Api + id);
                var zetel = JsonConvert.DeserializeObject<Zetel>(json);
                Zetel = zetel;
                return zetel;
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
            }
            return null;
        }
    }
}
