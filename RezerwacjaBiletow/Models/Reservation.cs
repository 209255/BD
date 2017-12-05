using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaBiletow.Models
{
    public class Reservation
    {

        public int ID { get; set; }
        public int ID_Seance { get; set; }
        public int ID_Klient { get; set; }
        public int SeatNumber { get; set; }
        public int ID_Cinema { get; set; }
    }
}
