using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
    class Melding: INotifyPropertyChanged
    {
        private string _inhoud;
        public string Inhoud {
            get {
                return _inhoud;
            }
            set {
                _inhoud = value;
                RaisePropertyChanged("Inhoud");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
