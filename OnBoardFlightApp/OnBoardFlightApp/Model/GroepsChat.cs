using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
    public class GroepsChat : INotifyPropertyChanged
    {
        private string naam;

        public string Naam
        {
            get { return naam; }
            set { naam = value; RaisePropertyChanged("Naam"); }
        }

        private List<Passagier> passagiers;

        public List<Passagier> Passagiers
        {
            get { return passagiers; }
            set { passagiers = value; RaisePropertyChanged("Passagiers"); }
        }

        private List<ChatBericht> chatberichten;

        public List<ChatBericht> ChatBerichten
        {
            get { return chatberichten; }
            set { chatberichten = value; RaisePropertyChanged("ChatBerichten"); }
        }

        public GroepsChat()
        {
            this.naam = "lege chat";
            passagiers = new List<Passagier>();
            chatberichten = new List<ChatBericht>();
        }
        public GroepsChat(string naam)
        {
            this.naam = naam;
            passagiers = new List<Passagier>();
            chatberichten = new List<ChatBericht>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
