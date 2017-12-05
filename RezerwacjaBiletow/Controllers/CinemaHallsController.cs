using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RezerwacjaBiletow.Models;

namespace RezerwacjaBiletow.Controllers
{
    public class CinemaHallsController : Controller
    {
        private readonly RezerwacjaBiletowContext _context;

        public CinemaHallsController(RezerwacjaBiletowContext context)
        {
            _context = context;
        }

        // GET: CinemaHalls
        public async Task<IActionResult> Index()
        {
            return View(await _context.CinemaHall.ToListAsync());
        }

        // GET: CinemaHalls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaHall = await _context.CinemaHall
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cinemaHall == null)
            {
                return NotFound();
            }

            return View(cinemaHall);
        }

        // GET: CinemaHalls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CinemaHalls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,NumberOfSeats,ID_Cinema")] CinemaHall cinemaHall)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinemaHall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinemaHall);
        }

        // GET: CinemaHalls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaHall = await _context.CinemaHall.SingleOrDefaultAsync(m => m.ID == id);
            if (cinemaHall == null)
            {
                return NotFound();
            }
            return View(cinemaHall);
        }

        // POST: CinemaHalls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,NumberOfSeats,ID_Cinema")] CinemaHall cinemaHall)
        {
            if (id != cinemaHall.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinemaHall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinemaHallExists(cinemaHall.ID))
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
            return View(cinemaHall);
        }

        // GET: CinemaHalls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaHall = await _context.CinemaHall
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cinemaHall == null)
            {
                return NotFound();
            }

            return View(cinemaHall);
        }

        // POST: CinemaHalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaHall = await _context.CinemaHall.SingleOrDefaultAsync(m => m.ID == id);
            _context.CinemaHall.Remove(cinemaHall);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinemaHallExists(int id)
        {
            return _context.CinemaHall.Any(e => e.ID == id);
        }
    }
}
