using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaBiletow.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }
        public string ImgPath { get; set; }
        public int ID_Cinema { get; set; }
    }
}
