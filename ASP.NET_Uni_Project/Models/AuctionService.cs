using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Uni_Project.Models
{
    public class AuctionService : IAuctionService
    {
        private readonly AppDbContext _context;

        public AuctionService(AppDbContext context)
        {
            _context = context;
        }

        public int Create(Auction auction)
        {
            try
            {
                var newAuction = _context.Auctions.Add(auction);
                _context.SaveChanges();
                return newAuction.Entity.Id;
            }
            catch
            {
                return -1;
            }
        }

        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }
            var auctionToDelete = _context.Auctions.Find(id);
            if (auctionToDelete is not null)
            {
                _context.Auctions.Remove(auctionToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Auction auction)
        {
            try
            {
                var auctionToUpdate = _context.Auctions.Find(auction.Id);
                if (auctionToUpdate is not null)
                {
                    auctionToUpdate.Name = auction.Name;
                    auctionToUpdate.Description = auction.Description;
                    auctionToUpdate.StartingBid = auction.StartingBid;
                    auctionToUpdate.Buyout = auction.Buyout;
                    auctionToUpdate.CloseDate = auction.CloseDate;
                    auctionToUpdate.GameId = auction.GameId;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Auction? FindById(int? id)
        {
            return id is null ? null : _context.Auctions.Include(a => a.Game).FirstOrDefault(m => m.Id == id);
        }

        public ICollection<Auction> FindAll()
        {
            return _context.Auctions.Include(a => a.Game).ToList();
        }

        public void CheckIfExpired()
        {
            var appDbContext = _context.Auctions.Include(a => a.Game);
            foreach (Auction auction in appDbContext)
            {
                if (DateTime.Compare(auction.CloseDate, DateTime.Now) < 0)
                {
                    auction.IsActive = false;
                    _context.Update(auction);
                }
                _context.SaveChangesAsync();
            }
        }

        public bool DoBid(Auction auction)
        {
            try
            {
                var auctionToUpdate = _context.Auctions.Find(auction.Id);
                if(auction.WinningBid<auctionToUpdate.WinningBid || auction.WinningBid < auctionToUpdate.StartingBid)
                {
                    return false;
                }
                if (auctionToUpdate is not null)
                {
                    auctionToUpdate.WinningBid = auction.WinningBid;
                    auctionToUpdate.Winner = auction.Winner;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DoBuy(Auction auction)
        {
            try
            {
                var auctionToUpdate = _context.Auctions.Find(auction.Id);
                if (auctionToUpdate is not null)
                {
                    auctionToUpdate.WinningBid = auctionToUpdate.Buyout;
                    auctionToUpdate.Winner = auction.Winner;
                    auctionToUpdate.IsActive = false;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
