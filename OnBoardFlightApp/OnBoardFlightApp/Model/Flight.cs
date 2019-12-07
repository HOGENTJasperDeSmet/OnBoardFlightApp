using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
   public class Flight : INotifyPropertyChanged
    {
        #region Properties
        private string naam;
        public string Naam {
            get {
                return naam;
            }
            set {
                naam = value;
                RaisePropertyChanged(nameof(Naam));
            }
        }
        private Locatie origine;
        public Locatie Origine
        {
            get
            {
                return origine;
            }
            set
            {
                origine = value;
                RaisePropertyChanged("Origine");
            }
        }
        private Locatie bestemming;
        public Locatie Bestemming
        {
            get
            {
                return bestemming;
            }
            set
            {
                bestemming = value;
                RaisePropertyChanged("Bestemming");
            }
        }
        private int duurInUren;
        public int DuurInUren
        {
            get
            {
                return duurInUren;
            }
            set
            {
                duurInUren = value;
                RaisePropertyChanged("DuurInUren");
            }
        }

        #endregion


        #region Constructors
        public Flight(string naam, Locatie origine, Locatie bestemming, int duurInUren)
        {
            Naam = naam;
            Origine = origine;
            Bestemming = bestemming;
            DuurInUren = duurInUren;
        }
        public Flight()
        {
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
