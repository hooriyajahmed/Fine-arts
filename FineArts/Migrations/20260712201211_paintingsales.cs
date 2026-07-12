using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineArts.Migrations
{
    /// <inheritdoc />
    public partial class paintingsales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "paintingsales",
                columns: table => new
                {
                    PaintingSaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitionPaintingId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paintingsales", x => x.PaintingSaleId);
                    table.ForeignKey(
                        name: "FK_paintingsales_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_paintingsales_exhibitionpaintings_ExhibitionPaintingId",
                        column: x => x.ExhibitionPaintingId,
                        principalTable: "exhibitionpaintings",
                        principalColumn: "ExhibitionPaintingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_paintingsales_CustomerId",
                table: "paintingsales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_paintingsales_ExhibitionPaintingId",
                table: "paintingsales",
                column: "ExhibitionPaintingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paintingsales");
        }
    }
}
