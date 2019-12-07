using OnBoardFlightApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlightApp.ViewModel
{
   public class PlayMovieViewModel
    {
        public Movie Movie { get; set; }

        public PlayMovieViewModel()
        {
           Movie = new Movie();
        }
    }
}
