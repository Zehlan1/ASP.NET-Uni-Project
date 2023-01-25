using ASP.NET_Uni_Project.Controllers;
using ASP.NET_Uni_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Assert = Xunit.Assert;

namespace CoreFunctionsTest
{
    public class Tests
    {
        private IAuctionService service = new AuctionServiceTest();
        private AuctionsController controller;

        public Tests()
        {
            controller = new AuctionsController(service);
            service.Create(new Auction() { Name = "Wiedümak Trzy TANIO", Description = "Okaza≥o sie øe syn juø ma", IsActive = true, StartingBid = 20, WinningBid = 45, Buyout = 200, Creator = "Janusz", Winner = "Pawe≥", GameId = 1, CloseDate = DateTime.Parse("2023-06-14 15:00:00") });
            service.Create(new Auction() { Name = "Fallout 2 nie otwierana", Description = "Nigdy nie otwierana edycja standardowa.", IsActive = true, StartingBid = 20, Buyout = 200, Creator = "Janusz", GameId = 2, CloseDate = DateTime.Parse("2023-02-14 17:00:00") });
            service.Create(new Auction() { Name = "Graj jako Wielki Polak Robert Lewandowski - Fifa 21", Description = "Fifa 21 uøywana, posiada bonus przedpremierowy!", IsActive = true, StartingBid = 20, WinningBid = 90, Buyout = 320, Creator = "Marian", Winner = "Bogumi≥a", GameId = 5, CloseDate = DateTime.Parse("2023-01-31 00:00:00") });
            service.Create(new Auction() { Name = "!HIT! The Outer Worlds Folia !HIT!", Description = "Wersja pude≥kowa z podpisem twÛrcÛw, nie otwierana.", IsActive = true, StartingBid = 120, WinningBid = 250, Buyout = 400, Creator = "Ubuwewue Aguweuwe Osass", Winner = "Gigachad", GameId = 6, CloseDate = DateTime.Parse("2023-09-22 19:59:59") });
            service.Create(new Auction() { Name = "Fallout 3 do sprzedania", Description = "Kupi≥em sobie nowπ czÍúÊ", IsActive = false, StartingBid = 30, WinningBid = 150, Buyout = 150, Creator = "Micha≥", Winner = "xXxRealGamerxXx", GameId = 3, CloseDate = DateTime.Parse("2023-06-14 15:00:00") });
            service.Create(new Auction() { Name = "Wiedümin 3 Nie Otwierana", Description = "Nowa gra z serii Wiedümin. Nie otwierana!", IsActive = true, StartingBid = 80, WinningBid = 110, Buyout = 240, Creator = "Dingo Game Shop", Winner = "TheRealGeraltOfRivia", GameId = 1, CloseDate = DateTime.Parse("2023-01-21 12:00:00") });
        }

        [Xunit.Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void TestAuctionsControllerGet(int id)
        {
            Auction createdAuction = new Auction() { Name = "Wiedümin 3", Description = "Brak", IsActive = true, StartingBid = 40, WinningBid = 45, Buyout = 215, Creator = "BigBoi93", Winner = "Nyanners", GameId = 1, CloseDate = DateTime.Parse("2023-02-14 10:00:00") };
            var task = controller.GetAuction(id);
            ActionResult<Auction> actionResult = Assert.IsType<ActionResult<Auction>>(task);
            Auction auction = Assert.IsType<Auction>(actionResult.Value);
            Assert.Equal(auction.Id, service.FindById(auction.Id).Id);
        }

        [Fact]
        public void TestAuctionsControllerGetAll()
        {
            var auctionList = controller.GetAuctions();
            ActionResult<IEnumerable<Auction>> result = Assert.IsType<ActionResult<IEnumerable<Auction>>>(auctionList);
            IEnumerable<Auction> auctions = Assert.IsAssignableFrom<IEnumerable<Auction>>(result.Value);
            Assert.Equal(6, auctions.Count());
        }

        [Fact]
        public void TestAuctionsControllerDelete()
        {
            Auction createdAuction = new Auction() { Name = "Wiedümin 3", Description = "Brak", IsActive = true, StartingBid = 40, WinningBid = 45, Buyout = 215, Creator = "BigBoi93", Winner = "Nyanners", GameId = 1, CloseDate = DateTime.Parse("2023-02-14 10:00:00") };
            var task = controller.DeleteAuction(1);
            NoContentResult noContentResult = Assert.IsType<NoContentResult>(task);
            var book = service.FindById(1);
            Assert.Null(book);
        }

        [Fact]
        public void TestBooksControllerPost()
        {
            Auction createdAuction = new Auction() { Name = "Wiedümin 3", Description = "Brak", IsActive = true, StartingBid = 40, WinningBid = 45, Buyout = 215, Creator = "BigBoi93", Winner = "Nyanners", GameId = 1, CloseDate = DateTime.Parse("2023-02-14 10:00:00") };
            var task = controller.PostAuction(createdAuction);
            var createdResult = Assert.IsType<CreatedResult>(task);
            Assert.NotNull(service.FindById(createdAuction.Id));
        }
    }
}