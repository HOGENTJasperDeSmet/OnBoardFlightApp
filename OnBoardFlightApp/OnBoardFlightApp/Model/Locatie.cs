﻿using System;
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
        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        public Locatie(string naam, string adres, double lattitude, double longitude)
        {
            Naam = naam;
            Adres = adres;
            Lattitude = lattitude;
            Longitude = longitude;
        }
        public Locatie()
        {

        }
    }
}
