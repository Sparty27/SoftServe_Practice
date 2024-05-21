using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftServe_Practice.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieSessionTicketPriceRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Sessions");

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "TicketPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TicketPrices_SessionId",
                table: "TicketPrices",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketPrices_Sessions_SessionId",
                table: "TicketPrices",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketPrices_Sessions_SessionId",
                table: "TicketPrices");

            migrationBuilder.DropIndex(
                name: "IX_TicketPrices_SessionId",
                table: "TicketPrices");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "TicketPrices");

            migrationBuilder.AddColumn<decimal>(
                name: "TicketPrice",
                table: "Sessions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
