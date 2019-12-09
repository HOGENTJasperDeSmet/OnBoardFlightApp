using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
    public class Passagier
    {

        #region Properties
        public int Id { get; set; }
        public Zetel Zetel { get; set; }
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        // public ICollection<Bestelling> Bestellingen { get; set; }
        public ICollection<Passagier> Reisgezelschap { get; set; }
        #endregion

        #region Constructors
        public Passagier()
        {
            Reisgezelschap = new List<Passagier>();
        }
        public Passagier(string voornaam, string naam)
        {
            this.Voornaam = voornaam;
            this.Naam = naam;
            Reisgezelschap = new List<Passagier>();
        }
        #endregion
    }
}


=======
    class Passagier
    {
        public int Id { get; set; }
        public Zetel Zetel { get; set; }
    }
}
>>>>>>> ff3dfeb6c55ffdd2db01f09b8dfc8ce881a4ada5
