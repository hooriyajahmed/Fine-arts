using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineArts.Migrations
{
    /// <inheritdoc />
    public partial class staff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_awards_compettions_CompetitionId",
                table: "awards");

            migrationBuilder.DropForeignKey(
                name: "FK_compettions_staffs_StaffId",
                table: "compettions");

            migrationBuilder.DropForeignKey(
                name: "FK_paintings_compettions_CompetitionId",
                table: "paintings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_compettions",
                table: "compettions");

            migrationBuilder.RenameTable(
                name: "compettions",
                newName: "Competition");

            migrationBuilder.RenameIndex(
                name: "IX_compettions_StaffId",
                table: "Competition",
                newName: "IX_Competition_StaffId");

            migrationBuilder.AddColumn<int>(
                name: "Staff_Id",
                table: "Competition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "imageurl",
                table: "Competition",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competition",
                table: "Competition",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_awards_Competition_CompetitionId",
                table: "awards",
                column: "CompetitionId",
                principalTable: "Competition",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competition_staffs_StaffId",
                table: "Competition",
                column: "StaffId",
                principalTable: "staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_paintings_Competition_CompetitionId",
                table: "paintings",
                column: "CompetitionId",
                principalTable: "Competition",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_awards_Competition_CompetitionId",
                table: "awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Competition_staffs_StaffId",
                table: "Competition");

            migrationBuilder.DropForeignKey(
                name: "FK_paintings_Competition_CompetitionId",
                table: "paintings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competition",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "Staff_Id",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "imageurl",
                table: "Competition");

            migrationBuilder.RenameTable(
                name: "Competition",
                newName: "compettions");

            migrationBuilder.RenameIndex(
                name: "IX_Competition_StaffId",
                table: "compettions",
                newName: "IX_compettions_StaffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_compettions",
                table: "compettions",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_awards_compettions_CompetitionId",
                table: "awards",
                column: "CompetitionId",
                principalTable: "compettions",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_compettions_staffs_StaffId",
                table: "compettions",
                column: "StaffId",
                principalTable: "staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_paintings_compettions_CompetitionId",
                table: "paintings",
                column: "CompetitionId",
                principalTable: "compettions",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
