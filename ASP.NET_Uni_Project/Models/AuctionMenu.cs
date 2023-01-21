using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Uni_Project.Models
{
    public class AuctionMenu : IAuctionMenu
    {
        private readonly AppDbContext _context;

        public AuctionMenu(AppDbContext context)
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
        public Auction FindById(int? id)
        {
            if(id is null)
            {
                return null;
            }
            return _context.Auctions.Find(id);
        }
        public ICollection<Auction> FindAll()
        {
            return _context.Auctions.ToList();
        }
        public ICollection<Auction> FindByUser(string creator)
        {
            var auctionList = _context.Auctions.ToList();
            return auctionList.Where(auction => auction.Creator.Contains(creator)).ToList();
        }
    }
}
