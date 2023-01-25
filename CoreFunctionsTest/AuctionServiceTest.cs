using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Uni_Project.Models;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using static System.Collections.Specialized.BitVector32;

namespace CoreFunctionsTest
{
    public class AuctionServiceTest : IAuctionService
    {
        private Dictionary<int, Auction> _auctions;
        private int index = 0;
        public AuctionServiceTest()
        {
            _auctions = new Dictionary<int, Auction>();
        }
        public int Create(Auction auction)
        {
            auction.Id = nextIndex();
            _auctions.Add(auction.Id, auction);
            return auction.Id;
        }
        public bool Delete(int? id)
        {
            if (_auctions.ContainsKey((int)id))
            {
                _auctions.Remove((int)id);
                return true;
            }
            return false;
        }
        public bool Update(Auction auction)
        {
            if (_auctions.ContainsKey(auction.Id))
            {
                _auctions[auction.Id] = auction;
                return true;
            }
            return false;
        }
        public Auction? FindById(int? id)
        {
            if (_auctions.ContainsKey((int)id))
            {
                return _auctions[(int)id];
            }
            return null;
        }
        public ICollection<Auction> FindAll()
        {
            return _auctions.Values.ToList();
        }
        public void CheckIfExpired()
        {
            foreach(var auction in _auctions.Values)
            {
                if(DateTime.Compare(auction.CloseDate, DateTime.Now) < 0)
                {
                    _auctions[auction.Id].IsActive = false;
                }
            }
        }
        public bool DoBid(Auction auction)
        {
            if (_auctions[auction.Id].StartingBid > auction.WinningBid || _auctions[auction.Id].WinningBid > auction.WinningBid)
            {
                return false;
            }
            if (_auctions.ContainsKey(auction.Id))
            {
                _auctions[auction.Id].WinningBid = auction.WinningBid;
                _auctions[auction.Id].Winner = auction.Winner;
                return true;
            }
            return false;
        }
        public bool DoBuy(Auction auction)
        {
            if (_auctions.ContainsKey(auction.Id))
            {
                _auctions[auction.Id].WinningBid = auction.Buyout;
                _auctions[auction.Id].Winner = auction.Winner;
                _auctions[auction.Id].IsActive = false;
                return true;
            }
            return false;
        }

        private int nextIndex()
        {
            return ++index;
        }

    }

}
