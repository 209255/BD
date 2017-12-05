using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RezerwacjaBiletow.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace RezerwacjaBiletow.Controllers
{
    public class MoviesController : Controller
    {
        private readonly RezerwacjaBiletowContext _context;

        public MoviesController(RezerwacjaBiletowContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var idCinema = new SqlParameter("idCinema", 1);
            return View(await _context.Movie.FromSql("SelectMovie @idCinema", idCinema).ToListAsync());
           // return View(await _context.Movie.ToListAsync());
        }

        // GET: Movies/Data
        public async Task<IActionResult> Data()
        {
            var idCinema = new SqlParameter("idCinema", 1);
            var movies = await _context.Movie.FromSql("SelectMovie @idCinema", idCinema).ToListAsync();
            HttpContext.Session.SetString("movies", JsonConvert.SerializeObject(movies));
            return Json(movies);
        }


        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var idCinema = new SqlParameter("idCinema", 1);
            var movie = await _context.Movie.FromSql("SelectMovie @idCinema", idCinema)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Genre,Type,Rating,ImgPath,ID_Cinema")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        
        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var idCinema = new SqlParameter("idCinema", 1);
            var movie = await _context.Movie.FromSql("SelectMovie @idCinema", idCinema).SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Genre,Type,Rating,ImgPath,ID_Cinema")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var idCinema = new SqlParameter("idCinema", 1);
            var movie = await _context.Movie.FromSql("SelectMovie @idCinema", idCinema).SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var idCinema = new SqlParameter("idCinema", 1);
            var movie = await _context.Movie.FromSql("SelectMovie @idCinema", idCinema).SingleOrDefaultAsync(m => m.ID == id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
