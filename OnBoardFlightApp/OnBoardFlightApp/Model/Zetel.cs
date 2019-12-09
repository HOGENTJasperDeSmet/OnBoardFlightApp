using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
    public class Zetel: INotifyPropertyChanged
    {
        public int Id { get; set; }
        private int _rij;

        public int Rij {
            get {
                return _rij;
            }
            set {
                _rij = value;
                RaisePropertyChanged("Rij");

            }
        }
        private char _stoel;
        public char Stoel {
            get
            {
                return _stoel;
            }
            set
            {
                _stoel = value;
                RaisePropertyChanged("Stoel");

            }
        }
        private string _klasse;
        public string Klasse
        {
            get
            {
                return _klasse;
            }
            set
            {
                _klasse = value;
                RaisePropertyChanged("Klasse");

            }
        }
        private Passagier _passagier;
        public Passagier Passagier
        {
            get
            {
                return _passagier;
            }
            set
            {
                _passagier = value;
                RaisePropertyChanged("Passagier");

            }
        }
        public string GetZetel
        {
            get
            {
                return _rij.ToString() + _stoel.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
