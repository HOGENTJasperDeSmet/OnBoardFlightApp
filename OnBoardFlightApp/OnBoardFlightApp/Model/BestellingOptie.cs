using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
    class BestellingOptie : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private int _type { get; set; }
        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                RaisePropertyChanged("Type");
            }
        }

        private string _naam { get; set; }
        public string Naam
        {
            get
            {
                return _naam;
            }
            set
            {
                _naam = value;
                RaisePropertyChanged("Naam");
            }
        }
            private double _prijs { get; set; }
        public double Prijs
        {
            get
            {
                return _prijs;
            }
            set
            {
                _prijs = value;
                RaisePropertyChanged(nameof(Prijs));
            }
        }
        public string PrijsStr
        {
            get
            {
                return "€" + _prijs;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
