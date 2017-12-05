using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaBiletow.Models
{
    public class CinemaHall
    {
        public int ID { get; set; }        
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
        public int ID_Cinema { get; set; }

    }
}
