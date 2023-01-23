using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP.NETUniProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    founded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    release = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false),
                    GameSerieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameSeries_GameSerieId",
                        column: x => x.GameSerieId,
                        principalTable: "GameSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    startingBid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    winningBid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    buyout = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Winner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    closeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GameSeries",
                columns: new[] { "Id", "description", "genre", "name" },
                values: new object[,]
                {
                    { 1, "A postapocalyptic future roleplaying game.", "RPG", "Fallout" },
                    { 2, "Multiplayer football simulator.", "Sport", "Fifa" },
                    { 3, "Based on the books of Andrzej Sapkowski", "RPG", "The Witcher" },
                    { 4, "Space first person shooter.", "FPS", "The Outer Worlds" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "description", "founded", "name" },
                values: new object[,]
                {
                    { 1, "Polish producer.", new DateTime(2000, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "CD Projekt RED" },
                    { 2, "Makes RPG games.", new DateTime(1994, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obsidian" },
                    { 3, "Great buggy games", new DateTime(2009, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bethesda" },
                    { 4, "Making fat stacks of cash.", new DateTime(2005, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electronic Arts" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "description", "GameSerieId", "ProducerId", "release", "title" },
                values: new object[,]
                {
                    { 1, "Part 3 of Geralts epic journey!", 3, 1, new DateTime(2015, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher 3: Wild Hunt" },
                    { 2, "Long awaited sequel", 1, 2, new DateTime(1998, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fallout 2" },
                    { 3, "First part in the series to use first person perspective.", 1, 3, new DateTime(2008, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fallout 3" },
                    { 4, "Create your favourite football team.", 2, 4, new DateTime(2008, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fifa 09" },
                    { 5, "Collect all your favourite players in the new FUT mode!", 2, 4, new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fifa 21" },
                    { 6, "Space exploration/FPS made by the creators of Fallout", 4, 2, new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Outer Worlds" }
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "buyout", "closeDate", "Creator", "description", "GameId", "IsActive", "name", "startingBid", "Winner", "winningBid" },
                values: new object[,]
                {
                    { 1, 200m, new DateTime(2023, 6, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Janusz", "Okazało sie że syn już ma", 1, true, "Wiedźmak Trzy TANIO", 20m, "Paweł", 45m },
                    { 2, 200m, new DateTime(2023, 2, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), "Janusz", "Nigdy nie otwierana edycja standardowa.", 2, true, "Fallout 2 nie otwierana", 20m, null, null },
                    { 3, 320m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marian", "Fifa 21 używana, posiada bonus przedpremierowy!", 5, true, "Graj jako Wielki Polak Robert Lewandowski - Fifa 21", 20m, "Bogumiła", 90m },
                    { 4, 400m, new DateTime(2023, 6, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Ubuwewue Aguweuwe Osass", "Wersja pudełkowa z podpisem twórców, nie otwierana.", 6, true, "!HIT! The Outer Worlds Folia !HIT!", 120m, "Gigachad", 250m },
                    { 5, 150m, new DateTime(2023, 6, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Michał", "Kupiłem sobie nową część", 3, false, "Fallout 3 do sprzedania", 30m, "xXxRealGamerxXx", 150m },
                    { 6, 240m, new DateTime(2023, 6, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Dingo Game Shop", "Nowa gra z serii Wiedźmin. Nie otwierana!", 1, true, "Wiedźmin 3 Nie Otwierana", 80m, "TheRealGeraltOfRivia", 110m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_GameId",
                table: "Auctions",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameSerieId",
                table: "Games",
                column: "GameSerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ProducerId",
                table: "Games",
                column: "ProducerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameSeries");

            migrationBuilder.DropTable(
                name: "Producers");
        }
    }
}
