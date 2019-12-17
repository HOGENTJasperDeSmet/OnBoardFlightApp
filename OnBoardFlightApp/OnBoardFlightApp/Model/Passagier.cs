using OnBoardFlightApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
    public class Passagier : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _voornaam;
        public string Voornaam {
            get {
                return _voornaam;
            } set {
                _voornaam = value;
                RaisePropertyChanged("Voornaam");
            }
        }
        private string _naam;
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
        private GroepsChat _groepschat;
        public GroepsChat Groepschat
        {
            get
            {
                return _groepschat;
            }
            set
            {
                _groepschat = value;
                RaisePropertyChanged("Groepschat");
            }
        }
        private Zetel _zetel;
        public Zetel Zetel
        {
            get
            {
                return _zetel;
            }
            set
            {
                _zetel = value;
                RaisePropertyChanged("Zetel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public String getCode()
        {
            return Id + Naam + Voornaam;
        }
    }
}

