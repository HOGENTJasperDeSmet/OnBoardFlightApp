using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OnBoardFlightApp.Model
{
    class Weather : INotifyPropertyChanged
    {
        private string _naam;
        public string Naam {
            get {
                return _naam;
            }
            set {
                _naam = value;
                RaisePropertyChanged("Naam");
            }
        }
        private BitmapImage _icon;
        public BitmapImage Icon {
            get {
                return _icon;
            }
            set {
                _icon = value;
                RaisePropertyChanged("Icon");
            }
        }
        private string _temperatuur;
        public string Temperatuur {
            get {
                return _temperatuur;
            }
            set {
                _temperatuur = value;
                RaisePropertyChanged(nameof(Temperatuur));
            }
        }
        private string _description;
        public string Description {
            get {
                return _description;
            }
            set {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }
        public Weather()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
