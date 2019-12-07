using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
    public class Locatie
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }

        public Locatie(string naam, string adres)
        {
            Naam = naam;
            Adres = adres;
        }
        public Locatie()
        {

        }
    }
}
