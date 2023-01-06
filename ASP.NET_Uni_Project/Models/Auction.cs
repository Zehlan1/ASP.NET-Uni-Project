namespace ASP.NET_Uni_Project.Models
{
    public class Auction
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public decimal CurrentBid { get; set; }
        public decimal Buyout { get; set; }
        public string Creator { get; set; }
        public DateTime CloseDate { get; set; }
    }
}
