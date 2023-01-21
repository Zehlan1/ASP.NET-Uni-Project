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
        private readonly IAuctionService _auctionService;

        public AuctionController(AppDbContext context, IAuctionService auctionService)
        {
            _context = context;
            _auctionService = auctionService;
        }

        // GET: Auction
        public IActionResult Index()
        {
            return View(_auctionService.FindAll());
        }

        // GET: Auction/Details/5
        public IActionResult Details(int? id)
        {
            var auction = _auctionService.FindById(id);
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
        public IActionResult Create([Bind("Id,Name,Description,IsActive,StartingBid,WinningBid,Buyout,CloseDate,GameId,Creator")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                _auctionService.Create(auction);
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Title", auction.GameId);
            return View(auction);
        }

        // GET: Auction/Edit/5
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            var auction = _auctionService.FindById(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartingBid,Buyout,CloseDate,GameId")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                _auctionService.Update(auction);
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Title", auction.GameId);
            return View(auction);
        }

        // GET: Auction/Delete/5
        [Authorize(Roles ="admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var auction = _auctionService.FindById(id);
            if (auction == null)
            {
                return NotFound();
            }
            return View(auction);
        }

        // POST: Auction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_auctionService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("Couldn't delete the auction.");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Bid(int id, [Bind("Id,WinningBid,Winner")] Auction auction)
        {
            if (_auctionService.DoBid(auction))
            {
                return RedirectToAction("Details", new { id = auction.Id });
            }
            TempData["notice"] = "Incorrect value for Bid.";
            return RedirectToAction("Details", new { id = auction.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Buy(int id, [Bind("Id,IsActive,WinningBid,Winner")] Auction auction)
        {
            if (_auctionService.DoBuy(auction))
            {
                return RedirectToAction("Details", new { id = auction.Id });
            }
            return Problem("Couldnt buy the item.");
        }
    }
}
