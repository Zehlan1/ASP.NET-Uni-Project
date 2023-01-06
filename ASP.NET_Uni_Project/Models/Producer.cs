using System.Collections.Generic;

namespace ASP.NET_Uni_Project.Models
{
    public class Producer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Games { get; set; }
        public decimal StockValue { get; set; }
        public int Grade { get; set; }
    }
}
