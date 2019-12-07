using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
    class Bestelling : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private bool _afgehandeld;
        public bool Afgehandeld {
            get { return _afgehandeld; }
            set { _afgehandeld = value;
                RaisePropertyChanged("Afgehandeld"); }
        }
        public string AfgehandeldString
        {
            get
            {
                if (_afgehandeld)
                {
                    return "Bestelling is geleverd!";
                }
                else
                {
                    return "Bestelling komt er zo aan!";
                }
            }
        }
        public ICollection<BestellingTK> BestellingTKs { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
