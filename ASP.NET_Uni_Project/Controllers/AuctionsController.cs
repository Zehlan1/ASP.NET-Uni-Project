using ASP.NET_Uni_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Uni_Project.Controllers
{
    [Route("api/auctions")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private IAuctionService _auctionService;
        public AuctionsController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        //GET api/aucitons
        [HttpGet]
        public IEnumerable<Auction> Get()
        {
            return _auctionService.FindAll();
        }

        //GET api/auctions/{Id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Auction> Get(int id)
        {
            return _auctionService.FindById(id);
        }

        //POST api/auctions/
        [HttpPost]
        public ActionResult Post([FromBody] Auction auction)
        {
            _auctionService.Create(auction);
            return Created("", auction);
        }

        //DELETE api/auctions/{Id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _auctionService.Delete(id);
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
            if (_auctionService.Update(auction))
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
