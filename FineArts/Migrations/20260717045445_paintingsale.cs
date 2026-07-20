using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineArts.Migrations
{
    /// <inheritdoc />
    public partial class paintingsale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaintingSale_Customer_CustomerId",
                table: "PaintingSale");

            migrationBuilder.DropForeignKey(
                name: "FK_PaintingSale_exhibitionpaintings_ExhibitionPaintingId",
                table: "PaintingSale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaintingSale",
                table: "PaintingSale");

            migrationBuilder.RenameTable(
                name: "PaintingSale",
                newName: "paintingsales");

            migrationBuilder.RenameIndex(
                name: "IX_PaintingSale_ExhibitionPaintingId",
                table: "paintingsales",
                newName: "IX_paintingsales_ExhibitionPaintingId");

            migrationBuilder.RenameIndex(
                name: "IX_PaintingSale_CustomerId",
                table: "paintingsales",
                newName: "IX_paintingsales_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_paintingsales",
                table: "paintingsales",
                column: "PaintingSaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_paintingsales_Customer_CustomerId",
                table: "paintingsales",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_paintingsales_exhibitionpaintings_ExhibitionPaintingId",
                table: "paintingsales",
                column: "ExhibitionPaintingId",
                principalTable: "exhibitionpaintings",
                principalColumn: "ExhibitionPaintingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paintingsales_Customer_CustomerId",
                table: "paintingsales");

            migrationBuilder.DropForeignKey(
                name: "FK_paintingsales_exhibitionpaintings_ExhibitionPaintingId",
                table: "paintingsales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_paintingsales",
                table: "paintingsales");

            migrationBuilder.RenameTable(
                name: "paintingsales",
                newName: "PaintingSale");

            migrationBuilder.RenameIndex(
                name: "IX_paintingsales_ExhibitionPaintingId",
                table: "PaintingSale",
                newName: "IX_PaintingSale_ExhibitionPaintingId");

            migrationBuilder.RenameIndex(
                name: "IX_paintingsales_CustomerId",
                table: "PaintingSale",
                newName: "IX_PaintingSale_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaintingSale",
                table: "PaintingSale",
                column: "PaintingSaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaintingSale_Customer_CustomerId",
                table: "PaintingSale",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaintingSale_exhibitionpaintings_ExhibitionPaintingId",
                table: "PaintingSale",
                column: "ExhibitionPaintingId",
                principalTable: "exhibitionpaintings",
                principalColumn: "ExhibitionPaintingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
