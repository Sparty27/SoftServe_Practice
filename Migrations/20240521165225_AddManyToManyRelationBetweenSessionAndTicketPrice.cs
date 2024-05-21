using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftServe_Practice.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelationBetweenSessionAndTicketPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "SessionTicketPrice",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    TicketPriceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionTicketPrice", x => new { x.SessionId, x.TicketPriceId });
                    table.ForeignKey(
                        name: "FK_SessionTicketPrice_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionTicketPrice_TicketPrices_TicketPriceId",
                        column: x => x.TicketPriceId,
                        principalTable: "TicketPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionTicketPrice_TicketPriceId",
                table: "SessionTicketPrice",
                column: "TicketPriceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionTicketPrice");

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
    }
}
