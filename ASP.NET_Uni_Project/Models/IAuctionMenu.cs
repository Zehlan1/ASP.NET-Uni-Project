namespace ASP.NET_Uni_Project.Models
{
    public interface IAuctionMenu
    {
        public int Create(Auction auction);
        public bool Delete(int? id);
        public bool Update(Auction auction);
        public Auction FindById(int? id);
        public ICollection<Auction> FindAll();
        public ICollection<Auction> FindByUser(string creator);
    }
}
