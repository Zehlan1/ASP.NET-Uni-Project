using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETUniProject.Migrations
{
    /// <inheritdoc />
    public partial class Version20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Auctions",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "currentBid",
                table: "Auctions",
                newName: "CurrentBid");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Auctions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentBid",
                table: "Auctions",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Auctions",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "CurrentBid",
                table: "Auctions",
                newName: "currentBid");

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Auctions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "currentBid",
                table: "Auctions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
