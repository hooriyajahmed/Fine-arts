using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineArts.Migrations
{
    /// <inheritdoc />
    public partial class exhibitionpaintings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exhibitionpaintings",
                columns: table => new
                {
                    ExhibitionPaintingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitionId = table.Column<int>(type: "int", nullable: false),
                    PaintingId = table.Column<int>(type: "int", nullable: false),
                    QuotedPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SoldPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SoldStatus = table.Column<bool>(type: "bit", nullable: false),
                    PaymentGiven = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exhibitionpaintings", x => x.ExhibitionPaintingId);
                    table.ForeignKey(
                        name: "FK_exhibitionpaintings_exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "exhibitions",
                        principalColumn: "ExhibitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exhibitionpaintings_paintings_PaintingId",
                        column: x => x.PaintingId,
                        principalTable: "paintings",
                        principalColumn: "PaintingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_exhibitionpaintings_ExhibitionId",
                table: "exhibitionpaintings",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_exhibitionpaintings_PaintingId",
                table: "exhibitionpaintings",
                column: "PaintingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exhibitionpaintings");
        }
    }
}
