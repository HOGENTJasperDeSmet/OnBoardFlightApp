using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<ChatBericht> chatberichten;

        public ObservableCollection<ChatBericht> ChatBerichten
        {
            get { return chatberichten; }
            set { chatberichten = value; RaisePropertyChanged("ChatBerichten"); }
        }

        public GroepsChat()
        {
            Naam = naam;
            Passagiers = new List<Passagier>();
            ChatBerichten = new ObservableCollection<ChatBericht>();
        }
        public GroepsChat(string naam, List<Passagier> passagiers, ObservableCollection<ChatBericht> chatberichten)
        {
            Naam = naam;
            Passagiers = passagiers;
            ChatBerichten = chatberichten;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
