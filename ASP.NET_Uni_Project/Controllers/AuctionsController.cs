using ASP.NET_Uni_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<Auction?>> GetAuctions()
        {
            if (_auctionService is null)
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<Auction?>>(_auctionService.FindAll());
        }

        //GET api/auctions/{Id}
        [HttpGet("{id}")]
        public ActionResult<Auction?> GetAuction(int id)
        {
            if (_auctionService is null)
            {
                return NotFound();
            }
            return _auctionService.FindById(id);
        }

        //POST api/auctions/
        [HttpPost]
        public ActionResult PostAuction([FromBody] Auction auction)
        {
            if (_auctionService == null)
            {
                return Problem("Service Not Found.");
            }
            if (ModelState.IsValid)
            {
                var createdId = _auctionService.Create(auction);
                return Created($"/api/auctions/{createdId}", createdId);
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE api/auctions/{Id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAuction(int id)
        {
            if (_auctionService == null)
            {
                return NotFound();
            }
            var result = _auctionService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        //PUT api/auctions/{Id}
        [HttpPut("{id}")]
        public ActionResult PutAuction(int id, [FromBody] Auction auction)
        {
            if (id != auction.Id)
            {
                return BadRequest();
            }
            auction.Id = id;
            _auctionService.Update(auction);
            return NoContent();
        }

        //PUT api/auctions/{Id}/bid
        [HttpPut]
        [Route("{id}/bid")]
        public ActionResult PutBid([FromRoute] int id, [FromBody] Auction auction)
        {
            if (_auctionService.FindById(id) is null)
            {
                return NotFound();
            }
            if (_auctionService.DoBid(auction))
            {
                return Ok();
            }
            return Problem("Couldn't put bid.");
        }

        //PUT api/auctions/{Id}/buy
        [HttpPut]
        [Route("{id}/buy")]
        public ActionResult PutBuy([FromRoute] int id, [FromBody] Auction auction)
        {
            if (_auctionService.FindById(id) is null)
            {
                return NotFound();
            }
            if (_auctionService.DoBuy(auction))
            {
                return Ok();
            }
            return Problem("Couldn't buy the item.");
        }
    }
}
