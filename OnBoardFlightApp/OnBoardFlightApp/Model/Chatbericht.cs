using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
    public class ChatBericht
    {
        public int id { get; set; }
        public string inhoud { get; set; }
        public DateTime datumVerzonden { get; set; }
        public String passagier { get; set; }

        public ChatBericht()
        {

        }

        public ChatBericht(String passagier, DateTime datum, string inhoud)
        {
            this.passagier = passagier;
            this.datumVerzonden = datum;
            this.inhoud = inhoud;
        }
    }
}