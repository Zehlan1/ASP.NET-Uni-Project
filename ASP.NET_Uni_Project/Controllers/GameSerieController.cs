using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Uni_Project.Models;

namespace ASP.NET_Uni_Project.Controllers
{
    public class GameSerieController : Controller
    {
        private readonly AppDbContext _context;

        public GameSerieController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GameSerie
        public async Task<IActionResult> Index()
        {
              return View(await _context.GameSeries.ToListAsync());
        }

        // GET: GameSerie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GameSeries == null)
            {
                return NotFound();
            }

            var gameSerie = await _context.GameSeries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameSerie == null)
            {
                return NotFound();
            }

            return View(gameSerie);
        }

        // GET: GameSerie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameSerie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Genre")] GameSerie gameSerie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameSerie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameSerie);
        }

        // GET: GameSerie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GameSeries == null)
            {
                return NotFound();
            }

            var gameSerie = await _context.GameSeries.FindAsync(id);
            if (gameSerie == null)
            {
                return NotFound();
            }
            return View(gameSerie);
        }

        // POST: GameSerie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Genre")] GameSerie gameSerie)
        {
            if (id != gameSerie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameSerie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameSerieExists(gameSerie.Id))
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
            return View(gameSerie);
        }

        // GET: GameSerie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GameSeries == null)
            {
                return NotFound();
            }

            var gameSerie = await _context.GameSeries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameSerie == null)
            {
                return NotFound();
            }

            return View(gameSerie);
        }

        // POST: GameSerie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GameSeries == null)
            {
                return Problem("Entity set 'AppDbContext.GameSeries'  is null.");
            }
            var gameSerie = await _context.GameSeries.FindAsync(id);
            if (gameSerie != null)
            {
                _context.GameSeries.Remove(gameSerie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameSerieExists(int id)
        {
          return _context.GameSeries.Any(e => e.Id == id);
        }
    }
}
