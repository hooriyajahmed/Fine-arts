using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineArts.Migrations
{
    /// <inheritdoc />
    public partial class exhibitionpainting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitionPainting_exhibitions_ExhibitionId",
                table: "ExhibitionPainting");

            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitionPainting_paintings_PaintingId",
                table: "ExhibitionPainting");

            migrationBuilder.DropForeignKey(
                name: "FK_PaintingSale_ExhibitionPainting_ExhibitionPaintingId",
                table: "PaintingSale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExhibitionPainting",
                table: "ExhibitionPainting");

            migrationBuilder.DropColumn(
                name: "PaymentGiven",
                table: "ExhibitionPainting");

            migrationBuilder.DropColumn(
                name: "SoldStatus",
                table: "ExhibitionPainting");

            migrationBuilder.RenameTable(
                name: "ExhibitionPainting",
                newName: "exhibitionpaintings");

            migrationBuilder.RenameIndex(
                name: "IX_ExhibitionPainting_PaintingId",
                table: "exhibitionpaintings",
                newName: "IX_exhibitionpaintings_PaintingId");

            migrationBuilder.RenameIndex(
                name: "IX_ExhibitionPainting_ExhibitionId",
                table: "exhibitionpaintings",
                newName: "IX_exhibitionpaintings_ExhibitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_exhibitionpaintings",
                table: "exhibitionpaintings",
                column: "ExhibitionPaintingId");

            migrationBuilder.AddForeignKey(
                name: "FK_exhibitionpaintings_exhibitions_ExhibitionId",
                table: "exhibitionpaintings",
                column: "ExhibitionId",
                principalTable: "exhibitions",
                principalColumn: "ExhibitionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_exhibitionpaintings_paintings_PaintingId",
                table: "exhibitionpaintings",
                column: "PaintingId",
                principalTable: "paintings",
                principalColumn: "PaintingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaintingSale_exhibitionpaintings_ExhibitionPaintingId",
                table: "PaintingSale",
                column: "ExhibitionPaintingId",
                principalTable: "exhibitionpaintings",
                principalColumn: "ExhibitionPaintingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exhibitionpaintings_exhibitions_ExhibitionId",
                table: "exhibitionpaintings");

            migrationBuilder.DropForeignKey(
                name: "FK_exhibitionpaintings_paintings_PaintingId",
                table: "exhibitionpaintings");

            migrationBuilder.DropForeignKey(
                name: "FK_PaintingSale_exhibitionpaintings_ExhibitionPaintingId",
                table: "PaintingSale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_exhibitionpaintings",
                table: "exhibitionpaintings");

            migrationBuilder.RenameTable(
                name: "exhibitionpaintings",
                newName: "ExhibitionPainting");

            migrationBuilder.RenameIndex(
                name: "IX_exhibitionpaintings_PaintingId",
                table: "ExhibitionPainting",
                newName: "IX_ExhibitionPainting_PaintingId");

            migrationBuilder.RenameIndex(
                name: "IX_exhibitionpaintings_ExhibitionId",
                table: "ExhibitionPainting",
                newName: "IX_ExhibitionPainting_ExhibitionId");

            migrationBuilder.AddColumn<bool>(
                name: "PaymentGiven",
                table: "ExhibitionPainting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoldStatus",
                table: "ExhibitionPainting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExhibitionPainting",
                table: "ExhibitionPainting",
                column: "ExhibitionPaintingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitionPainting_exhibitions_ExhibitionId",
                table: "ExhibitionPainting",
                column: "ExhibitionId",
                principalTable: "exhibitions",
                principalColumn: "ExhibitionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitionPainting_paintings_PaintingId",
                table: "ExhibitionPainting",
                column: "PaintingId",
                principalTable: "paintings",
                principalColumn: "PaintingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaintingSale_ExhibitionPainting_ExhibitionPaintingId",
                table: "PaintingSale",
                column: "ExhibitionPaintingId",
                principalTable: "ExhibitionPainting",
                principalColumn: "ExhibitionPaintingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
