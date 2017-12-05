using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RezerwacjaBiletow.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RezerwacjaBiletow.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
           
            return View();
        }

        private Movie FindMovieById(Movie[] movies, Int32 id)
        {
            foreach(Movie movie in movies)
            {
                if(movie.ID == id)
                {
                    return movie;
                }
            }
            return null;
        }

        public IActionResult Reservation(int film)
        {
            var movies = HttpContext.Session.GetString("movies");
            if (movies == null)
            {
                return Redirect("/Home");
            }
            var deserializedMovies = JsonConvert.DeserializeObject<Movie[]>(movies);
            var selectedMovie = this.FindMovieById(deserializedMovies, film);
            if(selectedMovie != null)
            {
                ViewData["MovieId"] = "Rezerwujesz miejsca na film:  " + selectedMovie.Title;
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return View();
        }

        public IActionResult Finalize()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
