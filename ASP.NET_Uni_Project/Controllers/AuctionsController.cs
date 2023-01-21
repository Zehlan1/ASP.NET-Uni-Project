using ASP.NET_Uni_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Uni_Project.Controllers
{
    [Route("api/auctions")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private IAuctionMenu _auctionMenu;
        public AuctionsController(IAuctionMenu auctionMenu)
        {
            _auctionMenu = auctionMenu;
        }

        //GET api/aucitons
        [HttpGet]
        public IEnumerable<Auction> Get()
        {
            return _auctionMenu.FindAll();
        }

        //GET api/auctions/{Id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Auction> Get(int id)
        {
            return _auctionMenu.FindById(id);
        }

        //POST api/auctions/
        [HttpPost]
        public ActionResult Post([FromBody] Auction auction)
        {
            _auctionMenu.Create(auction);
            return Created("", auction);
        }

        //DELETE api/auctions/{Id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _auctionMenu.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        //PUT api/auctions/{Id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Auction auction)
        {
            auction.Id = (int)id;
            if (_auctionMenu.Update(auction))
            {
                return BadRequest();
            }
            return NoContent();
        }

        //GET api/auctions/{name}
        //[HttpGet("{name}", Name = "GetByUser")]
        //public IEnumerable<Auction> GetByUser(string name)
        //{
        //    return _auctionMenu.FindByUser(name);
        //}
    }
}
