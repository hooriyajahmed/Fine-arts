using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineArts.Migrations
{
    /// <inheritdoc />
    public partial class award : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Award_competitions_CompetitionId",
                table: "Award");

            migrationBuilder.DropForeignKey(
                name: "FK_Award_students_StudentId",
                table: "Award");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Award",
                table: "Award");

            migrationBuilder.RenameTable(
                name: "Award",
                newName: "awards");

            migrationBuilder.RenameIndex(
                name: "IX_Award_StudentId",
                table: "awards",
                newName: "IX_awards_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Award_CompetitionId",
                table: "awards",
                newName: "IX_awards_CompetitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_awards",
                table: "awards",
                column: "AwardId");

            migrationBuilder.AddForeignKey(
                name: "FK_awards_competitions_CompetitionId",
                table: "awards",
                column: "CompetitionId",
                principalTable: "competitions",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_awards_students_StudentId",
                table: "awards",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_awards_competitions_CompetitionId",
                table: "awards");

            migrationBuilder.DropForeignKey(
                name: "FK_awards_students_StudentId",
                table: "awards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_awards",
                table: "awards");

            migrationBuilder.RenameTable(
                name: "awards",
                newName: "Award");

            migrationBuilder.RenameIndex(
                name: "IX_awards_StudentId",
                table: "Award",
                newName: "IX_Award_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_awards_CompetitionId",
                table: "Award",
                newName: "IX_Award_CompetitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Award",
                table: "Award",
                column: "AwardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Award_competitions_CompetitionId",
                table: "Award",
                column: "CompetitionId",
                principalTable: "competitions",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Award_students_StudentId",
                table: "Award",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
