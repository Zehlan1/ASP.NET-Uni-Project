namespace ASP.NET_Uni_Project.Models
{
    public class FinishedAuction
    {
        public int AuctionID { get; set; }
        public int CreatorID { get; set; }
        public int winnerID { get; set; }
        public decimal WinningBid { get; set; }
        public DateTime CloseDate { get; set; }
    }
}
