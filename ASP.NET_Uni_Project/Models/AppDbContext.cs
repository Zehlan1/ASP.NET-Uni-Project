using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Uni_Project.Models;

public class AppDbContext: DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<GameSerie> GameSeries { get; set; }
    public DbSet<Auction> Auctions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producer>().HasData(
            new Producer() {Id = 1, Name = "CD Projekt RED", Description = "Polish producer.", Founded = DateTime.Parse("2000-02-13")},
            new Producer() {Id = 2, Name = "Obsidian", Description = "Makes RPG games.", Founded = DateTime.Parse("1994-01-18")},
            new Producer() {Id = 3, Name = "Bethesda", Description = "Great buggy games", Founded = DateTime.Parse("2009-07-03")},
            new Producer() {Id = 4, Name = "Electronic Arts", Description = "Making fat stacks of cash.", Founded = DateTime.Parse("2005-07-23")}
        );
        modelBuilder.Entity<GameSerie>().HasData(
            new GameSerie() {Id = 1, Name = "Fallout", Description = "A postapocalyptic future roleplaying game.", Genre = "RPG"},
            new GameSerie() {Id = 2, Name = "Fifa", Description = "Multiplayer football simulator.", Genre = "Sport" },
            new GameSerie() {Id = 3, Name = "The Witcher", Description = "Based on the books of Andrzej Sapkowski", Genre = "RPG" },
            new GameSerie() {Id = 4, Name = "The Outer Worlds", Description = "Space first person shooter.", Genre = "FPS" }
        );
        modelBuilder.Entity<Game>().HasData(
            new Game() {Id = 1, Title = "The Witcher 3: Wild Hunt", Description = "Part 3 of Geralts epic journey!", GameSerieId = 3, ProducerId = 1, Release = DateTime.Parse("2015-06-14")},
            new Game() {Id = 2, Title = "Fallout 2", Description = "Long awaited sequel", GameSerieId = 1, ProducerId = 2, Release = DateTime.Parse("1998-04-19")},
            new Game() {Id = 3, Title = "Fallout 3", Description = "First part in the series to use first person perspective.", GameSerieId = 1, ProducerId = 3, Release = DateTime.Parse("2008-09-27")},
            new Game() {Id = 4, Title = "Fifa 09", Description = "Create your favourite football team.", GameSerieId = 2, ProducerId = 4, Release = DateTime.Parse("2008-06-18")},
            new Game() {Id = 5, Title = "Fifa 21", Description = "Collect all your favourite players in the new FUT mode!", GameSerieId = 2, ProducerId = 4, Release = DateTime.Parse("2020-03-03")},
            new Game() {Id = 6, Title = "The Outer Worlds", Description = "Space exploration/FPS made by the creators of Fallout", GameSerieId = 4, ProducerId = 2, Release = DateTime.Parse("2019-11-26")}
            );
        modelBuilder.Entity<Auction>().HasData(
            new Auction() { Id = 1, Name = "Wiedźmak Trzy TANIO", Description = "Okazało sie że syn już ma", IsActive = true, StartingBid = 20, WinningBid = 45, Buyout = 200, Creator = "Janusz", Winner = "Paweł", GameId = 1,CloseDate = DateTime.Parse("2023-06-14 15:00:00") },
            new Auction() { Id = 2, Name = "Fallout 2 nie otwierana", Description = "Nigdy nie otwierana edycja standardowa.", IsActive = true, StartingBid = 20, Buyout = 200, Creator = "Janusz", GameId = 2, CloseDate = DateTime.Parse("2023-02-14 17:00:00") },
            new Auction() { Id = 3, Name = "Graj jako Wielki Polak Robert Lewandowski - Fifa 21", Description = "Fifa 21 używana, posiada bonus przedpremierowy!", IsActive = true, StartingBid = 20, WinningBid = 90, Buyout = 320, Creator = "Marian", Winner = "Bogumiła", GameId = 5, CloseDate = DateTime.Parse("2023-01-31 00:00:00") },
            new Auction() { Id = 4, Name = "!HIT! The Outer Worlds Folia !HIT!", Description = "Wersja pudełkowa z podpisem twórców, nie otwierana.", IsActive = true, StartingBid = 120, WinningBid = 250, Buyout = 400, Creator = "Ubuwewue Aguweuwe Osass", Winner = "Gigachad", GameId = 6, CloseDate = DateTime.Parse("2023-06-14 15:00:00") },
            new Auction() { Id = 5, Name = "Fallout 3 do sprzedania", Description = "Kupiłem sobie nową część", IsActive = false, StartingBid = 30, WinningBid = 150, Buyout = 150, Creator = "Michał", Winner = "xXxRealGamerxXx", GameId = 3, CloseDate = DateTime.Parse("2023-06-14 15:00:00") },
            new Auction() { Id = 6, Name = "Wiedźmin 3 Nie Otwierana", Description = "Nowa gra z serii Wiedźmin. Nie otwierana!", IsActive = true, StartingBid = 80, WinningBid = 110, Buyout = 240, Creator = "Dingo Game Shop", Winner = "TheRealGeraltOfRivia", GameId = 1, CloseDate = DateTime.Parse("2023-06-14 15:00:00") }
            );
    }
}
