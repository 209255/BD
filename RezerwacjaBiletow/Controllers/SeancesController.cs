using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RezerwacjaBiletow.Models;
using System.Data.SqlClient;

namespace RezerwacjaBiletow.Controllers
{
    public class SeancesController : Controller
    {
        private readonly RezerwacjaBiletowContext _context;

        public SeancesController(RezerwacjaBiletowContext context)
        {
            _context = context;
        }

        // GET: Seances
        public async Task<IActionResult> Index()
        {
            var idCinema = new SqlParameter("idCinema", 1);
            return View(await _context.Seance.FromSql("SelectSeance @idCinema", idCinema).ToListAsync());
            //return View(await _context.Seance.ToListAsync());
        }

        // GET: Seances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var idCinema = new SqlParameter("idCinema", 1);
            var seance = await _context.Seance.FromSql("SelectSeance @idCinema", idCinema)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (seance == null)
            {
                return NotFound();
            }

            return View(seance);
        }

        // GET: Seances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ID_CinemaHall,ID_Movie,Date,StartingTime,ID_Cinema")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seance);
        }

        // GET: Seances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var idCinema = new SqlParameter("idCinema", 1);
            var seance = await _context.Seance.FromSql("SelectSeance @idCinema", idCinema).SingleOrDefaultAsync(m => m.ID == id);
            if (seance == null)
            {
                return NotFound();
            }
            return View(seance);
        }

        // POST: Seances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ID_CinemaHall,ID_Movie,Date,StartingTime,ID_Cinema")] Seance seance)
        {
            if (id != seance.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeanceExists(seance.ID))
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
            return View(seance);
        }

        // GET: Seances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var idCinema = new SqlParameter("idCinema", 1);
            var seance = await _context.Seance.FromSql("SelectSeance @idCinema", idCinema)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (seance == null)
            {
                return NotFound();
            }

            return View(seance);
        }

        // POST: Seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seance = await _context.Seance.SingleOrDefaultAsync(m => m.ID == id);
            _context.Seance.Remove(seance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeanceExists(int id)
        {
            return _context.Seance.Any(e => e.ID == id);
        }
    }
}
