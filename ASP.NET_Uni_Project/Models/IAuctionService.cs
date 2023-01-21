namespace ASP.NET_Uni_Project.Models
{
    public interface IAuctionService
    {
        public int Create(Auction auction);
        public bool Delete(int? id);
        public bool Update(Auction auction);
        public Auction FindById(int? id);
        public ICollection<Auction> FindAll();
        public void CheckIfExpired();
        public bool DoBid(Auction auction);
        public bool DoBuy(Auction auction);
    }
}
