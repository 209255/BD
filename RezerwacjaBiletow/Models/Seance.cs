using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaBiletow.Models
{
    public class Seance
    {
        public int ID { get; set; }
        public int ID_CinemaHall { get; set; }
        public int ID_Movie { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartingTime { get; set; }
        public int ID_Cinema { get; set; }
    }
}
