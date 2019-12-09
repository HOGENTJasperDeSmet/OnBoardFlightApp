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
<<<<<<< HEAD

   public class Passagier
=======
    public class Passagier : INotifyPropertyChanged
>>>>>>> 0f0314a5fb73c2b980f665ddcf9f83e9fbea6e5f
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

