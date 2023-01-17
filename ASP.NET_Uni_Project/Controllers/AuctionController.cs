using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Uni_Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NET_Uni_Project.Controllers
{
    public class AuctionController : Controller
    {
        private readonly AppDbContext _context;

        public AuctionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Auction
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Auctions.Include(a => a.Game);
            await CheckIfExpired();
            return View(await appDbContext.ToListAsync());
        }

        public async Task CheckIfExpired()
        {
            var appDbContext = _context.Auctions.Include(a => a.Game);
            foreach (Auction auction in appDbContext)
            {
                if (DateTime.Compare(auction.CloseDate, DateTime.Now) < 0)
                {
                    auction.IsActive = false;
                    _context.Update(auction);
                }
                await _context.SaveChangesAsync();
            }
        }

        // GET: Auction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions
                .Include(a => a.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        // GET: Auction/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Title");
            return View();
        }

        // POST: Auction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsActive,CurrentBid,StartingBid,WinningBid,Buyout,CloseDate,GameId,Creator")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Title", auction.GameId);
            return View(auction);
        }

        // GET: Auction/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Title", auction.GameId);
            return View(auction);
        }

        // POST: Auction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IsActive,CurrentBid,StartingBid,WinningBid,Buyout,CloseDate,GameId,Creator")] Auction auction)
        {
            if (id != auction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuctionExists(auction.Id))
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
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Title", auction.GameId);
            return View(auction);
        }

        // GET: Auction/Delete/5
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions
                .Include(a => a.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        // POST: Auction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Auctions == null)
            {
                return Problem("Entity set 'AppDbContext.Auctions'  is null.");
            }
            var auction = await _context.Auctions.FindAsync(id);
            if (auction != null)
            {
                _context.Auctions.Remove(auction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Bid(int id, [Bind("Id,Name,Description,IsActive,CurrentBid,StartingBid,WinningBid,Buyout,CloseDate,GameId,Creator,Winner")] Auction auction)
        {
            if (id != auction.Id)
            {
                return NotFound();
            }
            //Auction currentAuction = await GMA(id);
            var currentAuction = await _context.Auctions
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auction.WinningBid > currentAuction.WinningBid && auction.WinningBid > currentAuction.StartingBid)
            {
            try
                {
                    _context.Attach(auction);
                    _context.Entry(auction).Property(r => r.WinningBid).IsModified = true;
                    _context.Entry(auction).Property(r => r.Winner).IsModified = true;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuctionExists(auction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = auction.Id });
            }
            TempData["notice"] = "Incorrect value for Bid.";
            return RedirectToAction("Details", new { id = auction.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Buy(int id, [Bind("Id,Name,Description,IsActive,CurrentBid,StartingBid,WinningBid,Buyout,CloseDate,GameId,Creator,Winner")] Auction auction)
        {
            if (id != auction.Id)
            {
                return NotFound();
            }
            try
            {
                var currentAuction = await _context.Auctions
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

                auction.WinningBid = currentAuction.Buyout;
                auction.IsActive = false;
                _context.Attach(auction);
                _context.Entry(auction).Property(r => r.WinningBid).IsModified = true;
                _context.Entry(auction).Property(r => r.Winner).IsModified = true;
                _context.Entry(auction).Property(r => r.IsActive).IsModified = true;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionExists(auction.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Details", new { id = auction.Id });
        }

        private bool AuctionExists(int id)
        {
          return _context.Auctions.Any(e => e.Id == id);
        }
    }
}
