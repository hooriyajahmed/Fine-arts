using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineArts.Migrations
{
    /// <inheritdoc />
    public partial class competition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "competitions",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Conditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwardDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Staff_Id = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitions", x => x.CompetitionId);
                    table.ForeignKey(
                        name: "FK_competitions_staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_competitions_StaffId",
                table: "competitions",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "competitions");
        }
    }
}
