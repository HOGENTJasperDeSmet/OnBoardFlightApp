﻿using Newtonsoft.Json;
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
    class VeranderZetelViewModel
    {
        public readonly string Api = "http://localhost:5000/api/Flight";
        public HttpClient Client;

        public List<Zetel> Zetels { get; set; } = new List<Zetel>();

        private string _token = "";
        public string Token
        {
            get { return _token; }
            set
            {
                _token = value;
            }
        }
        public VeranderZetelViewModel()
        {
            Client = new HttpClient();
        }

        public async Task<List<string>> GetZetels()
        {
            var json = await Client.GetStringAsync(new Uri(Api + "/zetels"));
            var list = JsonConvert.DeserializeObject<IEnumerable<Zetel>>(json);
            var stringLijst = new List<string>();
            foreach (var i in list)
            {
                Zetels.Add(i);
                if(i.Passagier != null)
                {
                    stringLijst.Add(i.Passagier.Naam + " op " + i.GetZetel);
                }
                else
                {
                    stringLijst.Add("Lege stoel op " + i.GetZetel);
                }
            }

            return stringLijst;
        }

        public async void VeranderZetel(int id1, int id2)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(Api + "/veranderzetel"),
                    Content = new StringContent(JsonConvert.SerializeObject(new { Id1 = id1, Id2 = id2}), Encoding.UTF8, "application/json")
                };
                await Client.SendAsync(request);
                await new MessageDialog("Succesvol verzet!").ShowAsync();
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
            }
        }
    }
}