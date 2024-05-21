using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftServe_Practice.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionTicketPrice_Sessions_SessionId",
                table: "SessionTicketPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionTicketPrice_TicketPrices_TicketPriceId",
                table: "SessionTicketPrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionTicketPrice",
                table: "SessionTicketPrice");

            migrationBuilder.RenameTable(
                name: "SessionTicketPrice",
                newName: "SessionTicketPrices");

            migrationBuilder.RenameIndex(
                name: "IX_SessionTicketPrice_TicketPriceId",
                table: "SessionTicketPrices",
                newName: "IX_SessionTicketPrices_TicketPriceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionTicketPrices",
                table: "SessionTicketPrices",
                columns: new[] { "SessionId", "TicketPriceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SessionTicketPrices_Sessions_SessionId",
                table: "SessionTicketPrices",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionTicketPrices_TicketPrices_TicketPriceId",
                table: "SessionTicketPrices",
                column: "TicketPriceId",
                principalTable: "TicketPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionTicketPrices_Sessions_SessionId",
                table: "SessionTicketPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionTicketPrices_TicketPrices_TicketPriceId",
                table: "SessionTicketPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionTicketPrices",
                table: "SessionTicketPrices");

            migrationBuilder.RenameTable(
                name: "SessionTicketPrices",
                newName: "SessionTicketPrice");

            migrationBuilder.RenameIndex(
                name: "IX_SessionTicketPrices_TicketPriceId",
                table: "SessionTicketPrice",
                newName: "IX_SessionTicketPrice_TicketPriceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionTicketPrice",
                table: "SessionTicketPrice",
                columns: new[] { "SessionId", "TicketPriceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SessionTicketPrice_Sessions_SessionId",
                table: "SessionTicketPrice",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionTicketPrice_TicketPrices_TicketPriceId",
                table: "SessionTicketPrice",
                column: "TicketPriceId",
                principalTable: "TicketPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
