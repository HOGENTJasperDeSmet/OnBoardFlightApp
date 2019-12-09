using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
    public class Zetel
    {
        public int Id { get; set; }
        public int Rij { get; set; }
        public char Stoel { get; set; }
        public string Klasse { get; set; }
        public Passagier Passagier { get; set; }
        public int PassagierKey { get; set; }


        public Zetel(int rij, char stoel, string klasse)
        {
            this.Rij = rij;
            this.Stoel = stoel;
            this.Klasse = klasse;
        }
        public Zetel() { }
    }
}
