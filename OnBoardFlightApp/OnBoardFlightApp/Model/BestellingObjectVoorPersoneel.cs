using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace OnBoardFlightApp.Model
{
    class BestellingObjectVoorPersoneel : INotifyPropertyChanged
    {
        public BestellingObjectVoorPersoneel()
        {
            HttpClient = new HttpClient();
        }
        public HttpClient HttpClient { get; set; }
        public int Id { get; set; }
        public string Token { get; set; }   
        private bool _afgehandeld;
        public bool Afgehandeld
        {
            get { return _afgehandeld; }
            set
            {
                _afgehandeld = value;
                ChangeAfgehandeld(value);
                RaisePropertyChanged("Afgehandeld");
            }
        }

        private Passagier _passagier;
        public Passagier Passagier
        {
            get { return _passagier; }
            set
            {
                _passagier = value;
                RaisePropertyChanged("Passagier");
            }
        }

        public async void ChangeAfgehandeld(bool afgehandeld)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri("http://localhost:5000/api/bestelling/" + Id),
                    Content = new StringContent(JsonConvert.SerializeObject(new { Afgehandeld = afgehandeld }), Encoding.UTF8, "application/json")
                };
                await HttpClient.SendAsync(request);
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
            }
        }
        public string AfgehandeldString
        {
            get
            {
                if (_afgehandeld)
                {
                    return "Bestelling is geleverd!";
                }
                else
                {
                    return "Bestelling komt er zo aan!";
                }
            }
        }
        public ICollection<BestellingTK> BestellingTKs { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
