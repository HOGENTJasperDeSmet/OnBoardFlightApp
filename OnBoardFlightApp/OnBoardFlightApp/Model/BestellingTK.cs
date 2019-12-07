using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.Model
{
    class BestellingTK
    {
        public int BestellingId { get; set; }
        public int BestellingOptieId { get; set; }
        public BestellingOptie BestellingOptie { get; set; }
        public int Aantal { get; set; }
    }
}
