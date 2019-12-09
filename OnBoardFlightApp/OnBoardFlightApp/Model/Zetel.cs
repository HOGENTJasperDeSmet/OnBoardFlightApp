using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
<<<<<<< HEAD
    public class Zetel
    {
        public int Id { get; set; }
        public int Rij { get; set; }
        public char Stoel { get; set; }
        public string Klasse { get; set; }
        public Passagier Passagier { get; set; }
        public int PassagierKey { get; set; }

=======
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
>>>>>>> 0f0314a5fb73c2b980f665ddcf9f83e9fbea6e5f

        public Zetel(int rij, char stoel, string klasse)
        {
            this.Rij = rij;
            this.Stoel = stoel;
            this.Klasse = klasse;
        }
        public Zetel() { }
<<<<<<< HEAD
=======

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
>>>>>>> 0f0314a5fb73c2b980f665ddcf9f83e9fbea6e5f
    }
}
