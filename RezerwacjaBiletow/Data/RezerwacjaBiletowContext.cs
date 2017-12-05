using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RezerwacjaBiletow.Models;

namespace RezerwacjaBiletow.Models
{
    public class RezerwacjaBiletowContext : DbContext
    {
        public RezerwacjaBiletowContext (DbContextOptions<RezerwacjaBiletowContext> options)
            : base(options)
        {
        }

        public DbSet<RezerwacjaBiletow.Models.Movie> Movie { get; set; }

        public DbSet<RezerwacjaBiletow.Models.Seance> Seance { get; set; }
        public DbSet<RezerwacjaBiletow.Models.Reservation> Rezervation { get; set; }
        public DbSet<RezerwacjaBiletow.Models.Klient> Klient { get; set; }
        public DbSet<RezerwacjaBiletow.Models.CinemaHall> CinemaHall { get; set; }
    }
}
