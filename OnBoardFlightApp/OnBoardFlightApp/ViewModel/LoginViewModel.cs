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
using Windows.UI.Popups;

namespace OnBoardFlightApp.ViewModel
{
    class LoginViewModel
    {
        public readonly string Api = "http://localhost:5000/api/Flight/login";
        public HttpClient Client;

        public LoginViewModel()
        {
            Client = new HttpClient();
        }

        public async Task<string> Login(string email, string wachtwoord)
        {
            try
            {
                var login = new { Email = email, Password = wachtwoord };
                var json = JsonConvert.SerializeObject(login);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(Api, data);

                string token = response.Content.ReadAsStringAsync().Result;
                string tokenstring = JsonConvert.DeserializeObject<string>(token);
                return tokenstring;
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
            }
            return null;
        }
    }
}
